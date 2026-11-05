using Practical8.Models;
using Practical8.Views;

namespace Practical8.Controllers
{
    public class InventoryController
    {
        ItemRepository repo = new ItemRepository();
        InventoryView view = new InventoryView();

        public void Run()
        {
            while (true)
            {
                string ch = view.ShowMenu();

                if (ch == "1")
                {
                    repo.Add(view.GetNewItem());
                    view.ShowMessage("Item added successfully!");
                }
                else if (ch == "2")
                    view.ShowItems(repo.GetAll());
                else if (ch == "3")
                {
                    repo.Update(view.GetUpdatedItem());
                    view.ShowMessage("Item updated successfully!");
                }
                else if (ch == "4")
                {
                    repo.Delete(view.GetIdToDelete());
                    view.ShowMessage("Item deleted successfully!");
                }
                else if (ch == "5")
                {
                    view.ShowMessage("Exiting...");
                    break;
                }
                else
                    view.ShowMessage("Invalid choice!");
            }
        }
    }
}
