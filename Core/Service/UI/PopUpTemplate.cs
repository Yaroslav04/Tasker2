using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.UI
{
    public abstract class PopUpTemplate
    {
        public static async Task ShowMessage(string _title, string _message)
        {
            await Shell.Current.DisplayAlert(_title, _message, "OK");
        }
        public static async Task<bool> BoolMessage(string _title, string _message)
        {
            bool answer = await Shell.Current.DisplayAlert(_title, _message, "Так", "Ні");
            return answer;
        }
        public static async Task<string> GetNumber(string _title, string _message)
        {
            string result = string.Empty;

            result = await Shell.Current.DisplayPromptAsync(_title, _message);
            Debug.WriteLine(result);
            if (TextManager.IsNumberValid(result))
            {
                return result;
            }

            return "0";
        }
        public static async Task<string> GetNumber(string _title, string _message, string _initialValue)
        {
            string result = string.Empty;

            result = await Shell.Current.DisplayPromptAsync(_title, _message, initialValue: _initialValue);
            if (TextManager.IsNumberValid(result))
            {
                return result;
            }

            return "0";
        }
        public static async Task<string> GetSimpleText(string _title, string _message)
        {
            string result = string.Empty;

            result = await Shell.Current.DisplayPromptAsync(_title, _message);
            if (result == null)
            {
                return string.Empty;
            }

            return result.Replace("\t", "").Replace("\n", "");
        }
        public static async Task<string> GetSimpleText(string _title, string _message, string _initialValue)
        {
            string result = string.Empty;

            result = await Shell.Current.DisplayPromptAsync(_title, _message, initialValue: _initialValue);
            if (result == null)
            {
                return string.Empty;
            }

            return result.Replace("\t", "").Replace("\n", "");
        }
        public static async Task<string> GetSimpleTextNotNull(string _title, string _message)
        {
            string result = string.Empty;
            bool sw = true;
            while (sw)
            {
                result = await Shell.Current.DisplayPromptAsync(_title, _message);

                if (String.IsNullOrWhiteSpace(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Поле не може бути порожнім", "OK");
                    continue;
                }

                sw = false;
            }

            return result.Replace("\t", "").Replace("\n", "");
        }
        public static async Task<string> GetSimpleTextNotNull(string _title, string _message, string _initialValue)
        {
            string result = string.Empty;
            bool sw = true;
            while (sw)
            {
                result = await Shell.Current.DisplayPromptAsync(_title, _message, initialValue: _initialValue);

                if (String.IsNullOrWhiteSpace(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Поле не може бути порожнім", "OK");
                    continue;
                }

                sw = false;
            }

            return result.Replace("\t", "").Replace("\n", "");
        }
        public static async Task<string> GetDate(string _title, string _message)
        {
            string result = string.Empty;
            bool sw = true;
            while (sw)
            {
                result = await Shell.Current.DisplayPromptAsync(_title, _message);

                if (String.IsNullOrWhiteSpace(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Поле не може бути порожнім", "OK");
                    continue;
                }

                if (!TextManager.IsDateValid(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Не вірно вказана дата, приклад 01.01.2020", "OK");
                    continue;
                }

                sw = false;
            }

            return result.Replace("\t", "").Replace("\n", "");
        }
        public static async Task<string> GetDate(string _title, string _message, string _initialValue)
        {
            string result = string.Empty;
            bool sw = true;
            while (sw)
            {
                result = await Shell.Current.DisplayPromptAsync(_title, _message, initialValue: _initialValue);

                if (String.IsNullOrWhiteSpace(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Поле не може бути порожнім", "OK");
                    continue;
                }

                if (!TextManager.IsDateValid(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Не вірно вказана дата, приклад 01.01.2020", "OK");
                    continue;
                }

                sw = false;
            }

            return result.Replace("\t", "").Replace("\n", "");
        }
        public static async Task<string> GetTime(string _title, string _message)
        {
            string result = string.Empty;
            bool sw = true;
            while (sw)
            {
                result = await Shell.Current.DisplayPromptAsync(_title, _message);

                if (String.IsNullOrWhiteSpace(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Поле не може бути порожнім", "OK");
                    continue;
                }

                if (!TextManager.IsTimeValid(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Не вірно вказаний час, приклад 09:00", "OK");
                    continue;
                }

                sw = false;
            }

            return result.Replace("\t", "").Replace("\n", "");
        }
        public static async Task<string> GetTime(string _title, string _message, string _initialValue)
        {
            string result = string.Empty;
            bool sw = true;
            while (sw)
            {
                result = await Shell.Current.DisplayPromptAsync(_title, _message, initialValue: _initialValue);

                if (String.IsNullOrWhiteSpace(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Поле не може бути порожнім", "OK");
                    continue;
                }

                if (!TextManager.IsTimeValid(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Не вірно вказаний час, приклад 09:00", "OK");
                    continue;
                }

                sw = false;
            }

            return result.Replace("\t", "").Replace("\n", "");
        }

        public static async Task<string> GetDateTime(string _title, string _message, string _initialValue)
        {
            string result = string.Empty;
            bool sw = true;
            while (sw)
            {
                result = await Shell.Current.DisplayPromptAsync(_title, _message, initialValue: _initialValue);

                if (String.IsNullOrWhiteSpace(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Поле не може бути порожнім", "OK");
                    continue;
                }

                if (!TextManager.IsDateTimeValid(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Не вірно вказана дата та час, приклад 01.01.2020 12:00:00", "OK");
                    continue;
                }

                sw = false;
            }

            return result.Replace("\t", "").Replace("\n", "");
        }

        public static async Task<string> GetElementNotNull(string _title, string _message, List<string> list)
        {
            string result = string.Empty;
            bool sw = true;
            while (sw)
            {
                result = await Shell.Current.DisplayActionSheet(_message, null, null, list.ToArray());
                Debug.WriteLine(result);
                if (String.IsNullOrWhiteSpace(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Поле не може бути порожнім", "OK");
                    continue;
                }
                sw = false;
            }

            return result.Replace("\t", "").Replace("\n", "");
        }
        public static async Task<string> GetElement(string _message, List<string> list)
        {
            string result = string.Empty;

            bool sw = true;
            while (sw)
            {
                result = await Shell.Current.DisplayActionSheet(_message, "Відміна", null, list.ToArray());

                if (result == "Відміна")
                {
                    return String.Empty;
                }

                if (String.IsNullOrWhiteSpace(result))
                {
                    await Shell.Current.DisplayAlert("Помилка", "Поле не може бути порожнім", "OK");
                    continue;
                }

                sw = false;
            }

            return result.Replace("\t", "").Replace("\n", "");
        }
    }
}
