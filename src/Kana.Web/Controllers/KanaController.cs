using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Kana.Model.Entities;
using Kana.Model.Enums;
using Kana.Model.Factories;
using Kana.Model.Helpers;
using Kana.Model.Interfaces.Service;

namespace Kana.Web.Controllers
{
    public class KanaController<THelper> : BaseController where THelper : KanaBaseFactory, new()
    {
        protected readonly IPdfExportService pdfExportService;
        protected readonly ICounterService counterService;
        protected readonly KanaBaseFactory BaseFactory;
        protected readonly string kanaType;

        public KanaController(IPdfExportService pdfExportService, ICounterService counterService, string kanaType)
        {
            this.pdfExportService = pdfExportService;
            this.counterService = counterService;
            this.kanaType = kanaType;
            this.BaseFactory = new THelper();
        }

        public void Index()
        {
            var groupedKana = BaseFactory.GroupedKana();
            PropertyBag.Add("groupedDefaultKana", groupedKana.Where(x => BaseFactory.DefaultKana.Contains(x.Key)));
            PropertyBag.Add("groupedDakutenKana", groupedKana.Where(x => BaseFactory.DakutenKana.Contains(x.Key)));
            PropertyBag.Add("groupedComboKana", groupedKana.Where(x => BaseFactory.ComboKana.Contains(x.Key)));
            PropertyBag.Add("sheetTypes", EnumHelper.ToList(typeof(SheetType)));
            PropertyBag.Add("kanaType", kanaType);
            RenderView("/kana/index");
        }

        public void CreateSheet(KanaGroup[] kanaGroups, int pages, int questionsOnARow, bool includePageNumbers, bool includeAnswerSheets, SheetType sheetType)
        {
            var kanas = BaseFactory.Kana(kanaGroups);

            sheetType = sheetType == 0 ? SheetType.Alternate : sheetType;
            pages = pages == 0 ? 1 : (pages > 20 ? 20 : pages);
            questionsOnARow = questionsOnARow == 0 ? 12 : questionsOnARow;

            var sheet = new Sheet(kanas, pages, questionsOnARow, sheetType, includePageNumbers, includeAnswerSheets);
            var count = counterService.Increment(kanaType);

            var webPath = ConfigurationManager.AppSettings["webPath"];
            var pdf = pdfExportService.ConvertHtmlToPdf("sheet", new Dictionary<string, object>{
                {"webPath", webPath},
                {"sheet", sheet},
                {"kanaType", kanaType.Capitalize() },
                {"headerLeft", $"{kanaType} #{count}"},
                {"headerRight", DateTime.Now.ToString("dd MMM yyyy HH:mm")},
                {"footerLeft", $"Auto generated at: {webPath}"},
                {"footerRight", "Created by Robin Lucassen" }
            });

            CancelView();

            Response.ContentType = "application/pdf";

            Response.AppendHeader("content-disposition", $"attachment; filename={kanaType}-{count}.pdf");
            Response.BinaryWrite(pdf);

        }
    }
}