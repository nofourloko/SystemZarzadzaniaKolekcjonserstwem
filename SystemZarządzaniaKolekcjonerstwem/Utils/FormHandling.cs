using System;

namespace SystemZarządzaniaKolekcjonerstwem.Utils
{
	public class FormHandling
	{
		public static bool kindFormHandler(string kind)
		{
			if (kind == "" && kind == null)
			{
				return false;
			}

			if(kind.Length < 4)
			{
				return false;
			}

			return true;
		}

        public static bool newItemFormHandler(string title, string price, string status, string rate)
        {

            if (title == "" && title == null)
            {
                return false;
            }

            if (status == "" && status == null)
            {
                return false;
            }

            if (price == "" && price == null)
            {
                return false;
            }

            if (!Int32.TryParse(price, out int p))
            {
                return false;
            }

            if (!Int32.TryParse(rate, out int r))
            {
                return false;
            }

            if(r < 1 || r > 10)
            {
                return false;
            }

            return true;
        }

        public static void newItemFormCleaner(Editor title, Editor status, Editor price, Editor rate)
        {
            title.Text = "";
            status.Text = "";
            price.Text = "";
            rate.Text = "";
        }
    }
}

