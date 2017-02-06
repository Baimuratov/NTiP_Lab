using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace View
{
    /// <summary>
    /// Предоставляет метод, оставляющий в тексте только те символы, которые представляют вещественное число
    /// </summary>
    public class DoubleFilter
    {
        /// <summary>
        /// Изменяет значение свойства Text элемента управления TextBox,
        /// оставляя только символы, которые будут представлять натуральное или дробное число
        /// </summary>
        /// <param name="textBox">передаваемый по ссылке элемент управления TextBox</param>
        public void FilterText(ref TextBox textBox)
        {
            string text = textBox.Text;
            int cursorPosition = textBox.SelectionStart;
            int deletedSymbols = 0;

            // удаление из текста всех символов, кроме десятичных цифр и запятых
            text = Regex.Replace(text, @"[^\d | \,]", (Match match) => { deletedSymbols++; return string.Empty; });

            bool textHasComma = false;

            // Делегат, указывающий на метод, который будет
            // вызываться при каждом обнаружении запятой в тексте.
            // Возвращает заменяющую строку
            MatchEvaluator myEvaluator = delegate (Match match)
            {
                if (textHasComma == false)
                {
                    textHasComma = true;
                    return ",";
                }
                else
                {
                    deletedSymbols++;
                    return string.Empty;
                }
            };

            // Удаление из текста всех запятых, кроме первой
            text = Regex.Replace(text, @"\,", myEvaluator);

            textBox.Text = text;
            textBox.SelectionStart = cursorPosition - deletedSymbols;
            textBox.Modified = false;
        }
    }
}
