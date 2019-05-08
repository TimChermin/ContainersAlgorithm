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
            ContainerColumns = new ContainerColumn[lenght];
            CreateColumns();
        }

        private void CreateColumns()
        {
            for (int l = 0; l < lenght; l++)
            {
                ContainerColumns[l] = new ContainerColumn(lenght, width, maxHeight);
            }
        }

        public bool CanPlaceContainer(Container container)
        {
            // checks?

            if (CanPlaceContainerColumn(container) == true)
            {
                return true;
            }
            return false;
        }

        public bool CanPlaceContainerColumn(Container container)
        {
            columnNr = 0;
            foreach (ContainerColumn column in ContainerColumns)
            {
                if (column.CanPlaceContainer() == true)
                {
                    return true;
                }
                columnNr++;
            }
            return false;
        }

        public void PlaceContainer(Container container)
        {
            ContainerColumns[columnNr].PlaceContainer(container);
        }

    }
}
