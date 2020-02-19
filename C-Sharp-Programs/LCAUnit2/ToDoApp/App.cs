using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    class App
    {
        private ItemRepository itemRepository;
        public ConsoleUtils consoleUtils;

        public App()
        {
            itemRepository = new ItemRepository();
            consoleUtils = new ConsoleUtils();
        }
        public void Start()
        {

        }
    }
}
