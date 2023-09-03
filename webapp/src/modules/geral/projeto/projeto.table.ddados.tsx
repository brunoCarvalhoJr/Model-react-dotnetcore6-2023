import { IGridDDados } from "../../../shared/types/dados.types";

const GridProjetoDDados: IGridDDados = {
    order: [
        {
            field: "name",
            sort: "asc",
        },
    ],
    filterInit: [
        {
            columnField: "name",
            operatorValue: "contains",
            value: "",
        },
    ],
    columns: [
        {
            field: "id",
            headerName: "Projeto",
            flex: 1,
        },
        {
            field: "name",
            headerName: "Nome",
            flex: 1,
        },
        {
            field: "location",
            headerName: "Endereço",
            flex: 1,
        },
    ],
};

export default GridProjetoDDados;
