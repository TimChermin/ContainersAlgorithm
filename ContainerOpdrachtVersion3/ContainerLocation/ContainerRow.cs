using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    public class ContainerRow
    {
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
            if (TryToPlaceContainerColumn(container) == true)
            {
                return true;
            }
            return false;
        }

        private bool TryToPlaceContainerColumn(Container container)
        {
            columnNr = 1;
            foreach (ContainerColumn column in ContainerColumns)
            {
                if (IfTheContainerHasCoolingOrValuablesIsItInfrontOrInTheBack(container, columnNr, ContainerColumns.Count()) == true)
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

        public bool IfTheContainerHasCoolingOrValuablesIsItInfrontOrInTheBack(Container container, int columnNr, int columnCount)
        {
            if (container.Cooling == true && columnNr == 1)
            {
                return true;
            }
            else if (container.Valuable == true && (columnNr == 1 || columnNr == columnCount) && container.Cooling == false)
            {
                return true;
            }
            else if (container.Valuable == false && container.Cooling == false)
            {
                return true;
            }
            return false;
        }
    }
}
