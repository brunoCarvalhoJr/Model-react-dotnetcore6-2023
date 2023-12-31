import { SvgIconComponent } from "@mui/icons-material";
import VoltarIcon from "@mui/icons-material/ArrowBack";
import KeyboardArrowDown from "@mui/icons-material/KeyboardArrowDown";
import KeyboardArrowRight from "@mui/icons-material/KeyboardArrowRight";
import {
    Autocomplete,
    Avatar,
    Collapse,
    Drawer,
    Fab,
    ListItem,
    ListItemButton,
    TextField,
    Typography,
    useMediaQuery,
    useTheme,
} from "@mui/material";
import { grey, green } from "@mui/material/colors";
import Divider from "@mui/material/Divider";
import List from "@mui/material/List";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import { styled } from "@mui/material/styles";
import { Box } from "@mui/system";
import { useEffect, useState } from "react";
import React from "react";
import { GlobalHotKeys } from "react-hotkeys";
import {
    useMatch,
    useNavigate,
    useResolvedPath,
    useLocation,
} from "react-router-dom";

import { MenuList } from "../../../menu";
import { useAppThemeContext, useDrawerContext } from "../../contexts";
import { BarraSuperior } from "../barra-superior/barraSuperior.component";
import { getTelasDoMenuRapido } from "../menu-rapido/menuRapido.component";

const drawerWidth = 240;
interface IListItemLinkProps {
    label: string;
    Icone: SvgIconComponent;
    to: string;
    onClick: (() => void) | undefined;
}

const ListItemLink: React.FC<IListItemLinkProps> = ({
    to,
    Icone,
    label,
    onClick,
}) => {
    const location = useLocation();
    const navigate = useNavigate();

    const resolvedPath = useResolvedPath(to);
    const match = useMatch({ path: resolvedPath.pathname, end: false });

    const handleClick = () => {
        if (location.pathname !== to) navigate(to);
        onClick?.();
    };

    return (
        <ListItemButton
            className="customBg"
            selected={!!match}
            key={label}
            onClick={handleClick}
        >
            <ListItemIcon>
                <Icone />
            </ListItemIcon>
            <ListItemText>
                <Typography
                    variant={"subtitle2"}
                    whiteSpace={"nowrap"}
                    textOverflow={"ellipsis"}
                    overflow={"hidden"}
                    fontWeight={500}
                >
                    {label}
                </Typography>
            </ListItemText>
        </ListItemButton>
    );
};

export const MenuLateral: React.FC<{ children: any }> = ({ children }) => {
    const [estado, setEstado] = useState<any>({});
    const [menuPaiSelecionado, setMenuPaiSelecionado] = useState<any | null>(
        {},
    );

    const theme = useTheme();

    const { themeName } = useAppThemeContext();

    const smDown = useMediaQuery(theme.breakpoints.down("md"));

    const { isDrawerOpen, toogleDrawerOpen, drawerOptions, setDrawerOptions } =
        useDrawerContext();

    const navigate = useNavigate();

    const hotKeysKeyMap = {
        MENU_RAPIDO: "ctrl+m",
    };

    const menuRapidoRef: any = React.createRef();

    const telasDoMenuRapido = getTelasDoMenuRapido(drawerOptions);

    const [telaAtual] = useState(undefined);

    const acessarMenuRapido = async () => {
        await toogleDrawerOpen();
        await menuRapidoRef.current?.focus();
    };

    const hotKeyshandlers = {
        MENU_RAPIDO: acessarMenuRapido,
    };

    useEffect(() => {
        setDrawerOptions(MenuList);
        if (isDrawerOpen) {
            menuRapidoRef.current?.focus();
        }
    }, [isDrawerOpen]);

    const DrawerHeader = styled("div")(({ theme }) => ({
        display: "flex",
        alignItems: "center",
        padding: theme.spacing(0, 1),
        ...theme.mixins.toolbar,
        justifyContent: "flex-end",
    }));

    const onChangeMenu = async (item: any, item2: any) => {
        if (location.pathname !== item2.value) await navigate(item2.value);
        await toogleDrawerOpen();
    };

    const handleClick = (e: any) => {
        console.log("passou 12");
        setMenuPaiSelecionado(e.index);
        setEstado({ [e.label]: !estado[e.label] });
    };

    const onClickSimpleMenu = () => {
        console.log("passou 13");
        if (smDown) {
            toogleDrawerOpen();
            setEstado({});
            setMenuPaiSelecionado(null);
        } else {
            setEstado({}), setMenuPaiSelecionado(undefined);
        }
    };

    return (
        <>
            <Box sx={{ display: "flex" }}>
                <BarraSuperior
                    open={isDrawerOpen}
                    handleDrawerOpen={toogleDrawerOpen}
                />
                <Drawer
                    sx={{
                        width: drawerWidth,
                        flexShrink: 0,
                        "& .MuiDrawer-paper": {
                            width: drawerWidth,
                            boxSizing: "border-box",
                        },
                    }}
                    variant={smDown ? "temporary" : "persistent"}
                    anchor="left"
                    onClose={toogleDrawerOpen}
                    open={isDrawerOpen}
                >
                    <DrawerHeader>
                        <Box
                            style={{ marginLeft: "15%" }}
                            width="100%"
                            height={theme.spacing(10)}
                            display="flex"
                            alignItems="center"
                            justifyContent="center"
                        >
                            {themeName === "light" && (
                                <Avatar
                                    variant="rounded"
                                    sx={{ heigth: 10, width: 100 }}
                                    src="https://images.gupy.io/unsafe/88x88/center/middle/https://s3.amazonaws.com/gupy5/production/companies/1692/career/2811/images/2021-07-27_20-28_logo.png"
                                />
                            )}
                            {themeName !== "light" && (
                                <Avatar
                                    variant="rounded"
                                    sx={{ heigth: 10, width: 100 }}
                                    src="http://smarapd.tecnologia.ws/wp-content/uploads/2016/07/cropped-icon-smara.png"
                                />
                            )}
                        </Box>
                        <Fab
                            size="small"
                            aria-label="add"
                            onClick={toogleDrawerOpen}
                            style={{
                                width: "25%",
                                height: "20%",
                                boxShadow: "none",
                            }}
                        >
                            <VoltarIcon />
                        </Fab>
                    </DrawerHeader>
                    <GlobalHotKeys
                        keyMap={hotKeysKeyMap}
                        handlers={hotKeyshandlers}
                    >
                        <Box width="100%">
                            {isDrawerOpen && (
                                <Autocomplete
                                    id="menuRapido"
                                    options={telasDoMenuRapido}
                                    value={telaAtual}
                                    defaultValue={telaAtual}
                                    getOptionLabel={(option) => option.label}
                                    size="small"
                                    style={{
                                        marginLeft: "4%",
                                        marginRight: "4%",
                                    }}
                                    onChange={(item, item2) =>
                                        onChangeMenu(item, item2)
                                    }
                                    renderInput={(params) => (
                                        <TextField
                                            {...params}
                                            inputRef={menuRapidoRef}
                                            name="menuRapido"
                                            id="menuRapido"
                                            variant="standard"
                                            label="Menu rápido (Ctrl + M)"
                                            placeholder="Digite aqui"
                                            required={true}
                                            InputLabelProps={{
                                                shrink: true,
                                            }}
                                        />
                                    )}
                                />
                            )}
                        </Box>
                    </GlobalHotKeys>
                    <Divider
                        style={{
                            marginTop: "15px",
                            background:
                                themeName === "light" ? green[100] : grey[400],
                        }}
                    />
                    <Box flex={1}>
                        <List component={"nav"}>
                            {drawerOptions.map((drawerOption) => {
                                return (
                                    <div key={drawerOption.id}>
                                        {drawerOption.items.map((item: any) => {
                                            return (
                                                <div key={item.id}>
                                                    {item.subitems != null ? (
                                                        <div
                                                            key={item.id}
                                                            style={{
                                                                cursor: "pointer",
                                                            }}
                                                        >
                                                            <ListItem
                                                                style={
                                                                    menuPaiSelecionado ===
                                                                        item?.index &&
                                                                    themeName ===
                                                                        "light"
                                                                        ? {
                                                                              border: "2px ridge ",
                                                                              borderColor:
                                                                                  green[300],
                                                                              cursor: "pointer",
                                                                          }
                                                                        : menuPaiSelecionado ===
                                                                              item?.index &&
                                                                          themeName ===
                                                                              "dark"
                                                                        ? {
                                                                              border: "2px ridge ",
                                                                              borderColor:
                                                                                  grey[500],
                                                                              cursor: "pointer",
                                                                          }
                                                                        : {}
                                                                }
                                                                key={item.path}
                                                                onClick={handleClick.bind(
                                                                    this,
                                                                    item,
                                                                )}
                                                            >
                                                                <ListItemIcon>
                                                                    {estado[
                                                                        item
                                                                            .label
                                                                    ] ? (
                                                                        <KeyboardArrowDown />
                                                                    ) : (
                                                                        <KeyboardArrowRight />
                                                                    )}
                                                                </ListItemIcon>
                                                                <Typography
                                                                    color={
                                                                        themeName ===
                                                                        "dark"
                                                                            ? grey[200]
                                                                            : grey[600]
                                                                    }
                                                                    fontWeight={
                                                                        500
                                                                    }
                                                                    whiteSpace={
                                                                        "nowrap"
                                                                    }
                                                                    textOverflow={
                                                                        "ellipsis"
                                                                    }
                                                                    overflow={
                                                                        "hidden"
                                                                    }
                                                                >
                                                                    {item.label}
                                                                </Typography>
                                                            </ListItem>
                                                            <Collapse
                                                                key={item.path}
                                                                component="li"
                                                                in={
                                                                    estado[
                                                                        item
                                                                            .label
                                                                    ]
                                                                }
                                                                timeout="auto"
                                                                unmountOnExit
                                                            >
                                                                <Box
                                                                    key={
                                                                        item.id
                                                                    }
                                                                    style={
                                                                        themeName ===
                                                                        "light"
                                                                            ? {
                                                                                  background:
                                                                                      grey[200],
                                                                              }
                                                                            : {
                                                                                  background:
                                                                                      grey[500],
                                                                              }
                                                                    }
                                                                >
                                                                    <List
                                                                        disablePadding
                                                                    >
                                                                        {item.subitems.map(
                                                                            (
                                                                                sitem: any,
                                                                            ) => {
                                                                                return (
                                                                                    <ListItemLink
                                                                                        key={
                                                                                            sitem.path
                                                                                        }
                                                                                        to={
                                                                                            sitem.path
                                                                                        }
                                                                                        Icone={
                                                                                            sitem.icon
                                                                                        }
                                                                                        label={
                                                                                            sitem.label
                                                                                        }
                                                                                        onClick={
                                                                                            smDown
                                                                                                ? () =>
                                                                                                      toogleDrawerOpen()
                                                                                                : undefined
                                                                                        }
                                                                                    />
                                                                                );
                                                                            },
                                                                        )}
                                                                    </List>
                                                                </Box>
                                                                <Divider />
                                                            </Collapse>
                                                        </div>
                                                    ) : (
                                                        <ListItemLink
                                                            key={item.path}
                                                            to={item.path}
                                                            Icone={item.icon}
                                                            label={item.label}
                                                            onClick={() =>
                                                                onClickSimpleMenu()
                                                            }
                                                        />
                                                    )}
                                                </div>
                                            );
                                        })}
                                    </div>
                                );
                            })}
                        </List>
                    </Box>
                </Drawer>
                <Box
                    paddingX={3}
                    width={"100%"}
                    style={{
                        paddingTop: "5%",
                        marginLeft: !isDrawerOpen ? `-${drawerWidth}px` : "",
                    }}
                >
                    {children}
                </Box>
            </Box>
        </>
    );
};
