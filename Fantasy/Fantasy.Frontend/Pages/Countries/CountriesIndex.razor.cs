using Fantasy.Frontend.Repositories;
using Microsoft.AspNetCore.Components;
using Fantasy.Shared.Entities;

namespace Fantasy.Frontend.Pages.Countries
{
    public partial class CountriesIndex
    {
        [Inject] private IRepository Repository { get; set; } = null;

        private List<Country>? Countries { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await Repository.GetAsync<List<Country>>("api/Countries");
            Countries = responseHttp.Response;
        }
    }
}