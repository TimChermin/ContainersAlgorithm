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

        public ContainerColumn[] ContainerColumns { get; set; }

        public ContainerRow(int lenght)
        {
            ContainerColumns = new ContainerColumn[lenght];
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

        public void PlaceContainer()
        {
            ContainerColumns[columnNr].PlaceContainer();
        }

    }
}
