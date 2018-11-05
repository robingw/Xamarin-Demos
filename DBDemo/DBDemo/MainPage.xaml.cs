using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Services.DatabaseService.Model;
using DBDemo.Database;
using DBDemo.Database.Controller;
using Xamarin.Forms;

namespace DBDemo
{
    public partial class MainPage : ContentPage
    {
        private DatabaseHelper<TestTableController, TestTable> database = null;

        public MainPage()
        {
            InitializeComponent();

            if (database == null)
            {
                string databaseFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBDemo.db3");
                database = new DatabaseHelper<TestTableController, TestTable>(databaseFile);
            }

            Task.Run(async () =>
            {
                listView.ItemsSource = await database.GetItemsAsync();
            });
        }

        async Task Handle_Clicked(object sender, System.EventArgs e)
        {
            TestTable table = new TestTable
            {
                Name = "Demo",
                Description = "This is a database demo."
            };
            await database.SaveItemAsync(table);

            listView.ItemsSource = await database.GetItemsAsync();
        }
    }
}
