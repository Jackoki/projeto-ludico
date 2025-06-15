using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_ludico.View.EventsForms.EventsLendingParticipants
{
    internal static class EventLendingParticipantsUtil {

        public static void SetColumnDisplayIndex(DataGridView dataViewer, string[] columnNames) {
            for (int i = 0; i < columnNames.Length; i++) {
                var column = dataViewer.Columns[columnNames[i]];
                if (column != null) {
                    column.DisplayIndex = i;
                }
            }
        }

        public static void AddCustomButtons(DataGridView dataViewer, Func<DataGridViewColumn> createReturnButton, Func<DataGridViewColumn> createDeleteButton) {
            if (!dataViewer.Columns.Contains("btnReturn")) {
                var returnButton = createReturnButton();
                dataViewer.Columns.Add(returnButton);
            }

            if (!dataViewer.Columns.Contains("btnDelete"))  {
                var deleteButton = createDeleteButton();
                dataViewer.Columns.Add(deleteButton);
            }
        }
        public static void AddCustomButtons(DataGridView dataViewer, Func<DataGridViewColumn> createDeleteButton) {
            if (!dataViewer.Columns.Contains("btnDelete"))
            {
                var deleteButton = createDeleteButton();
                dataViewer.Columns.Add(deleteButton);
            }
        }


        public static void AddDateTimeFormatting(DataGridView dataViewer, string columnName, string dateFormat) {
            dataViewer.CellFormatting += (s, e) => {
                if (dataViewer.Columns[e.ColumnIndex].Name == columnName && e.Value != null) {
                    if (DateTime.TryParse(e.Value.ToString(), out var dateValue)) {
                        e.Value = dateValue.ToString(dateFormat);
                        e.FormattingApplied = true;
                    }
                }
            };
        }

        public static void AddStringFormatting(DataGridView dataViewer, string columnName) {
            dataViewer.CellFormatting += (s, e) => {
                if (dataViewer.Columns[e.ColumnIndex].Name == columnName && e.Value != null) {
                    e.Value = e.Value.ToString();
                    e.FormattingApplied = true;
                }
            };
        }



    }
}
