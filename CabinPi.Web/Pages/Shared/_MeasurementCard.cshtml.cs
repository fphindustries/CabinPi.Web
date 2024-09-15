using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CabinPi.Web.Pages.Shared
{
    public class _MeasurementCardModel : PageModel
    {
        public string? Caption { get; set; }
        public string? Value { get; set; }
        public string? Units { get; set; }
        public string? SparkId { get; set; }

        public string? Icon { get; set; }

        public void OnGet()
        {
        }
    }
}
