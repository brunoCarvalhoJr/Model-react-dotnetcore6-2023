interface IRouteType {
    name: string;
    path: string;
    accessControl: boolean;
    element: unknown;
    breadCrumb: Array<BreadCrumbType> | unknown;
}

type BreadCrumbType = {
    text: string;
    link?: string;
};

export default IRouteType;
