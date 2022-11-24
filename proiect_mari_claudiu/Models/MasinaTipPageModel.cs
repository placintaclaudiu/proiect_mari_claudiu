using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect_mari_claudiu.Data;

namespace proiect_mari_claudiu.Models
{
    public class MasinaTipPageModel : PageModel
    {
        public List<AssignedTipData> AssignedTipDataList;
        public void PopulateAssignedTipData(proiect_mari_claudiuContext context, Masina masina)
        {
            var allCategories = context.Tip;
            var masinaCategories = new HashSet<int>(
            masina.TipMasini.Select(c => c.TipID)); //
            AssignedTipDataList = new List<AssignedTipData>();
            foreach (var cat in allCategories)
            {
                AssignedTipDataList.Add(new AssignedTipData
                {
                    TipID = cat.ID,
                    Nume = cat.NumeTip,
                    Assigned = masinaCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateMasinaCategories(proiect_mari_claudiuContext context, string[] selectedCategories, Masina masinaToUpdate)
        {
            if (selectedCategories == null)
            {
                masinaToUpdate.TipMasini = new List<TipMasina>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var masinaCategories = new HashSet<int>
            (masinaToUpdate.TipMasini.Select(c => c.Tip.ID));
            foreach (var cat in context.Tip)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!masinaCategories.Contains(cat.ID))
                    {
                        masinaToUpdate.TipMasini.Add(new TipMasina
                        {
                            MasinaID = masinaToUpdate.ID,
                            TipID = cat.ID
                        });
                    }
                }
                else
                {
                    if (masinaCategories.Contains(cat.ID))
                    {
                        TipMasina courseToRemove
                        = masinaToUpdate
                        .TipMasini
                        .SingleOrDefault(i => i.TipID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
