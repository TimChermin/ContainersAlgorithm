using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    public class ContainerRow
    {
        private int rowNr;
        private int columnNr;
        private int lenght;
        private int width;
        private int maxHeight;

        public ContainerColumn[] ContainerColumns { get; set; }

        public ContainerRow(int lenght, int width, int maxHeight)
        {
            this.lenght = lenght;
            this.width = width;
            this.maxHeight = maxHeight;
            ContainerColumns = new ContainerColumn[width];
            CreateColumns();
        }

        private void CreateColumns()
        {
            for (int w = 0; w < width; w++)
            {
                ContainerColumns[w] = new ContainerColumn(lenght, width, maxHeight);
            }
        }

        public bool TryToPlaceContainer(Container container)
        {
            // checks?

            if (TryToPlaceContainerColumn(container) == true)
            {
                return true;
            }
            return false;
        }

        private bool TryToPlaceContainerColumn(Container container)
        {
            columnNr = 0;
            foreach (ContainerColumn column in ContainerColumns)
            {
                if (IfTheContainerHasCoolingIsItInfront(container, columnNr) == true)
                {
                    if (column.TryToPlaceContainer(container) == true)
                    {
                        return true;
                    }
                }
                columnNr++;
            }
            return false;
        }

        public bool IfTheContainerHasCoolingIsItInfront(Container container, int columnNr)
        {
            if (container.Cooling == true && columnNr != 0)
            {
                return false;
            }
            return true;
        }
    }
}
