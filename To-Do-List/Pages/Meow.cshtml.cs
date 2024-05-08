using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using ToDoClassLib;

namespace To_Do_List.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using System.Collections.Generic;

    public class MeowModel(IMemoryCache cache) : PageModel
    {
        private IMemoryCache Cache { get; } = cache;

        [BindProperty]
        public List<ChoreClass>? ChoreList { get; set; }

        [BindProperty]
        public string ChoreName { get; set; } = string.Empty;

        public void OnGet()
        {
            ChoreList = Cache.GetOrCreate("meowList", entry => new List<ChoreClass>());
        }

        public void OnPostAdd()
        {
            ChoreClass chore = new(ChoreName);
            ChoreList = Cache.GetOrCreate("meowList", entry => new List<ChoreClass>());
            ChoreList.Add(chore);
            ChoreName = string.Empty; 
            

            foreach (ChoreClass chores in ChoreList)
            {
                Console.WriteLine(chores.ChoreName);
                
            }
            Console.WriteLine("------------------");
            Cache.Set("meowList", ChoreList);
        }

        public void OnPostRemove(string meowser)
        {
            ChoreList = Cache.GetOrCreate("meowList", entry => new List<ChoreClass>());
            ChoreClass choreToRemove = ChoreList.FirstOrDefault(chore => chore.ChoreName == meowser);
            ChoreList.Remove(choreToRemove);
            Cache.Set("meowList", ChoreList);
        }
    }
}
