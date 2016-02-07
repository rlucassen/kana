using System;
using System.Collections.Generic;
using System.Linq;
using Kana.Model.Enums;
using Kana.Model.Helpers;

namespace Kana.Model.Entities
{
    public class Sheet
    {
        public Sheet(IList<Kana> kanas, int pages, int questionsOnARow, SheetType type = SheetType.Kana, bool includePageNumbers = true, bool includeAnswerSheets = false)
        {
            kanas = kanas.Where(x => x.Group != KanaGroup.Empty).ToList();
            Pages = new List<SheetPage>();
            var sheetType = type;
            bool evenRow = false;
            for (var pageCount = 1; pageCount <= pages; pageCount++)
            {
                var page = new SheetPage();
                page.PageNumber = pageCount;
                for (var rowCount = 1; rowCount <= 8; rowCount++)
                {
                    if(type == SheetType.Alternate && evenRow)
                        sheetType = SheetType.Kana;
                    if(type == SheetType.Alternate && !evenRow)
                        sheetType = SheetType.Romaji;

                    page.Rows.Add(new KanaRow(kanas.RandomItems(questionsOnARow), sheetType));
                    evenRow = !evenRow;
                }
                Pages.Add(page);
            }

            Type = type;
            QuestionOnARow = questionsOnARow;
            IncludePageNumbers = includePageNumbers;
            IncludeAnswerSheets = includeAnswerSheets;
        }

        public IList<SheetPage> Pages { get; set; }
        public SheetType Type { get; set; }
        public int QuestionOnARow { get; set; }
        public bool IncludePageNumbers { get; set; }
        public bool IncludeAnswerSheets { get; set; }
        public int RowSize => QuestionOnARow == 6 ? 2 : 1;
        public int InputSize => 50*RowSize;
        public int AnswerSize => 70*RowSize;
    }

    public class SheetPage
    {
        public SheetPage()
        {
            Rows = new List<KanaRow>();
        }

        public int PageNumber { get; set; }
        public IList<KanaRow> Rows { get; set; }
    }

    public class KanaRow
    {
        public KanaRow(IList<Kana> kanas, SheetType sheetType)
        {
            Questions = new List<Question>();
            foreach (var kana in kanas)
            {
                QuestionType questionType;
                switch (sheetType)
                {
                    case SheetType.Kana:
                        questionType = QuestionType.Kana;
                        break;
                    case SheetType.Romaji:
                        questionType = QuestionType.Romaji;
                        break;
                    case SheetType.Combined:
                        questionType = EnumHelper.Random<QuestionType>();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(sheetType), sheetType, null);
                }
                Questions.Add(new Question(kana, questionType));
            }
        }

        public IList<Question> Questions { get; set; }
    }

    public class Question
    {
        public Question(Kana kana, QuestionType type)
        {
            Kana = kana;
            Type = type;
        }

        public Kana Kana { get; set; }
        public QuestionType Type { get; set; }
    }
}