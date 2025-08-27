using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Snippets.Font;

namespace ProcessingTimeCalc
{
    public class PDFWriter
    {
        private PdfDocument? currentDocument;
        private PdfPage? currentPage;
        private XGraphics? currentGraphics;
        private XTextFormatter? currentTextFormatter;

        private const string DEFAULT_FONT_NAME = "Times New Roman";
        internal static readonly XFont ParagraphFont = new(DEFAULT_FONT_NAME, 14, XFontStyleEx.Regular);
        internal static readonly XFont[] HeaderFonts = new XFont[]
        {
            new (DEFAULT_FONT_NAME, 20, XFontStyleEx.Bold),
            new (DEFAULT_FONT_NAME, 18, XFontStyleEx.Bold),
            new (DEFAULT_FONT_NAME, 16, XFontStyleEx.Bold),

        };
        private static readonly int lineSpacing = 5;
        private int lastAddedTableRow = -1;
        private float storedLayoutY = 0;

        /// <summary>
        /// Начать работу с документом
        /// </summary>
        public void Open()
        {
            ApplyGlobalSettings();
            Dispose();
            currentDocument = new();
        }
        private bool TryAddPage(int nextLayoutIncrease)
        {
            if (storedLayoutY + nextLayoutIncrease > currentPage!.Height)
            {
                AddPage();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Перейти на новую страницу
        /// </summary>
        public void AddPage()
        {
            currentPage = currentDocument!.AddPage();
            currentGraphics = XGraphics.FromPdfPage(currentPage);
            currentTextFormatter = new(currentGraphics);
            storedLayoutY = 0;
            int verticalSpace = 25;
            int horizontalSpace = 25;
            currentPage.TrimMargins.Top = verticalSpace;
            currentPage.TrimMargins.Right = horizontalSpace;
            currentPage.TrimMargins.Bottom = verticalSpace;
            currentPage.TrimMargins.Left = horizontalSpace;
        }
        /// <summary>
        /// Установить заголовок
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title) => currentDocument!.Info.Title = title;
        /// <summary>
        /// Добавить межстроковый интервал
        /// </summary>
        /// <param name="em"></param>
        public void AddSpace(float em)
        {
            storedLayoutY += ParagraphFont.Height * em;
        }

        /// <summary>
        /// Добавить текстовый заголовок
        /// </summary>
        /// <param name="text"></param>
        /// <param name="headerIndex">H1, H2, H3</param>
        public void AddHeader(string text, int headerIndex)
        {
            AddText(text, HeaderFonts[headerIndex - 1], XBrushes.Black, XStringFormats.TopLeft);
        }
        /// <summary>
        /// Добавить параграф
        /// </summary>
        /// <param name="text"></param>
        /// <param name="linesCount"></param>
        public void AddParagraph(string text, int linesCount = 1)
        {
            AddText($"    {text}", ParagraphFont, XBrushes.Black, XStringFormats.TopLeft, linesCount);
        }
        /// <summary>
        /// Сбросить параметры оформления таблицы
        /// </summary>
        public void ResetTable()
        {
            lastAddedTableRow = -1;
        }
        /// <summary>
        /// Добавить строку таблицы
        /// </summary>
        /// <param name="columnsCount"></param>
        /// <param name="linesCount"></param>
        /// <param name="entries"></param>
        public void AddTableRow(int columnsCount, int linesCount, params string[] entries)
        {
            lastAddedTableRow++;
            XFont font = ParagraphFont;
            XBrush brush = XBrushes.Black;

            int layoutIncrease = font.Height * linesCount + lineSpacing;
            float tablePadding = 5;
            TryAddPage(layoutIncrease);
            float width = (float)currentPage!.Width / columnsCount;
            for (int i = 0; i < columnsCount; ++i)
            {
                float step = (float)i / columnsCount;
                XRect layout = new(currentPage!.Width * step, storedLayoutY, width, font.Height * linesCount);
                XRect tableLayout = layout;
                tableLayout.Y -= lineSpacing / 2f;
                tableLayout.Height += lineSpacing;
                layout.X += tablePadding;
                currentGraphics!.DrawRectangle(lastAddedTableRow % 2 == 0 ? XPens.WhiteSmoke : XPens.White, lastAddedTableRow % 2 == 0 ? XBrushes.WhiteSmoke : XBrushes.White, tableLayout);
                if (entries.Length > i)
                    currentTextFormatter!.DrawString(entries[i], font, brush, layout);
            }
            storedLayoutY += layoutIncrease;

        }
        /// <summary>
        /// Добавить любой текст
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="format"></param>
        /// <param name="linesCount"></param>
        public void AddText(string text, XFont font, XBrush brush, XStringFormat format, int linesCount = 1)
        {
            int layoutIncrease = font.Height * linesCount + lineSpacing;
            TryAddPage(layoutIncrease);
            XRect layout = GetPageTextLayout(font, linesCount);
            format.LineAlignment = XLineAlignment.Near;
            currentTextFormatter!.DrawString(text, font, brush, layout, format);

            storedLayoutY += layoutIncrease;
        }
        /// <summary>
        /// Добавить линию
        /// </summary>
        /// <param name="color"></param>
        /// <param name="pageScale"></param>
        public void AddLine(XKnownColor color, float pageScale = 1)
        {
            int width = 1;
            int layoutIncrease = width + lineSpacing;
            TryAddPage(layoutIncrease);
            XPen pen = new(XColor.FromKnownColor(color), width);
            currentGraphics!.DrawLine(pen, 0, storedLayoutY, currentPage!.Width * pageScale, storedLayoutY);
            storedLayoutY += layoutIncrease;
        }
        private XRect GetPageTextLayout(XFont currentFont, int linesCount = 1)
        {
            return new(0, storedLayoutY, currentPage!.Width, currentFont.Height * linesCount);
        }

        /// <summary>
        /// Сохранить документ
        /// </summary>
        public void Save()
        {
            if (!TryChooseDirectory(out SaveFileDialog dialog)) return;
            Save(dialog.FileName);
        }
        /// <summary>
        /// Сохранить документ
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            currentDocument?.Save(path);
        }

        private void Dispose()
        {
            currentDocument?.Dispose();
        }
        private static void ApplyGlobalSettings()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if (PdfSharp.Fonts.GlobalFontSettings.FontResolver is null)
            {
                GlobalFontSettings.FontResolver = new FailsafeFontResolver();
            }
        }
        private static bool TryChooseDirectory(out SaveFileDialog dialogMenu) => ChooseDirectory(out dialogMenu) == DialogResult.OK;
        private static DialogResult ChooseDirectory(out SaveFileDialog dialogMenu)
        {
            dialogMenu = new SaveFileDialog
            {
                InitialDirectory = Configuration.Instance.FilesData.DefaultPDFPath,
                Filter = "(*.pdf)|*.pdf",
                AddExtension = true,
                DefaultExt = "pdf",
                RestoreDirectory = true,
                FileName = Configuration.Instance.FilesData.DefaultPDFName,
            };
            return dialogMenu.ShowDialog();
        }
    }
}
