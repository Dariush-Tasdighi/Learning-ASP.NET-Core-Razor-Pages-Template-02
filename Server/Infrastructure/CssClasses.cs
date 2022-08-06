namespace Infrastructure
{
	public static class CssClasses : object
	{
		static CssClasses()
		{
		}

		public static string Link
		{
			get
			{
				var result =
					"text-decoration-none"
					;

				return result;
			}
		}

		public static string HorizontalRule
		{
			get
			{
				var result =
					"mt-4"
					;

				return result;
			}
		}

		public static string FormDivRow
		{
			get
			{
				var result =
					"row my-0 my-sm-1 my-md-3 my-lg-5"
					;

				return result;
			}
		}

		public static string FormDivCol
		{
			get
			{
				var result =
					"col-12 p-3"
					+
					" "
					+
					"col-md-8 offset-md-2 p-md-4"
					+
					" "
					+
					"col-lg-6 offset-lg-3 p-lg-5"
					+
					" "
					+
					"bg-light border border-2 rounded-3 shadow-lg"
					;

				return result;
			}
		}

		public static string FormFooterDiv
		{
			get
			{
				var result =
					"text-center"
					;

				return result;
			}
		}

		public static string FormFooterLink
		{
			get
			{
				var result =
					""
					;

				return result;
			}
		}

		public static string FormLegend
		{
			get
			{
				var result =
					""
					;

				return result;
			}
		}

		public static string FormFieldDiv
		{
			get
			{
				var result =
					"mb-3"
					;

				return result;
			}
		}

		public static string FormActionsDiv
		{
			get
			{
				var result =
					"mb-3"
					;

				return result;
			}
		}

		public static string ListActionsDivRow
		{
			get
			{
				var result =
					"row"
					;

				return result;
			}
		}

		public static string ListActionsDivCol
		{
			get
			{
				var result =
					"col"
					;

				return result;
			}
		}

		public static string ListActionsLink
		{
			get
			{
				var result =
					"btn btn-primary"
					;

				return result;
			}
		}

		public static string ListTableDivRow
		{
			get
			{
				var result =
					"row"
					;

				return result;
			}
		}

		public static string ListTableDivCol
		{
			get
			{
				var result =
					"col table-responsive"
					;

				return result;
			}
		}

		public static string ListTable
		{
			get
			{
				var result =
					"table table-bordered table-sm table-striped table-hover align-items-center"
					;

				return result;
			}
		}

		public static string ListTableHeader
		{
			get
			{
				var result =
					"table-primary text-center"
					;

				return result;
			}
		}

		public static string ListTableBody
		{
			get
			{
				var result =
					""
					;

				return result;
			}
		}

		public static string ListTableFooter
		{
			get
			{
				var result =
					"table-secondary"
					;

				return result;
			}
		}

		public static string ListTableActionsTd
		{
			get
			{
				var result =
					"text-center"
					;

				return result;
			}
		}

		public static string ListTableActionsLink
		{
			get
			{
				var result =
					"text-center"
					;

				return result;
			}
		}
	}
}
