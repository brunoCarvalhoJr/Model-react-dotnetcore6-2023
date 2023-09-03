import { ProjetoGrid } from "../components/projeto.grid";

type Props = {
    titulo?: string;
    children: React.ReactNode;
    loadingInicial?: boolean;
    ocultarBarraFerramentas?: boolean;
    propsBarraFerramentas?: any;
};

export const ProjetoList: React.FC<Props> = (/*{
    titulo,
    children,
    loadingInicial,
    ocultarBarraFerramentas,
    propsBarraFerramentas,
}: Props*/) => {
    return <ProjetoGrid />;
};
