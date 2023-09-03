import MenuIcon from "@mui/icons-material/Menu";
import { Grid } from "@mui/material";
import MuiAppBar, { AppBarProps as MuiAppBarProps } from "@mui/material/AppBar";
import IconButton from "@mui/material/IconButton";
import { styled } from "@mui/material/styles";
import Toolbar from "@mui/material/Toolbar";

import { MenuSimples } from "../menu-simples/menuSimples";

const drawerWidth = 240;

export const BarraSuperior = (props: {
    open: boolean | undefined;
    handleDrawerOpen: any;
}) => {
    interface IAppBarProps extends MuiAppBarProps {
        open?: boolean;
    }

    const AppBar = styled(MuiAppBar, {
        shouldForwardProp: (prop) => prop !== "open",
    })<IAppBarProps>(({ theme, open }) => ({
        transition: theme.transitions.create(["margin", "width"], {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen,
        }),
        ...(open && {
            width: `calc(100% - ${drawerWidth}px)`,
            marginLeft: `${drawerWidth}px`,
            transition: theme.transitions.create(["margin", "width"], {
                easing: theme.transitions.easing.easeOut,
                duration: theme.transitions.duration.enteringScreen,
            }),
        }),
    }));

    return (
        <AppBar position="fixed" open={props.open}>
            <Toolbar>
                <Grid container direction="row">
                    <Grid item xs>
                        <IconButton
                            color="inherit"
                            aria-label="open drawer"
                            onClick={props.handleDrawerOpen}
                            edge="start"
                            sx={{
                                mr: 2,
                                ...(props.open && { display: "none" }),
                            }}
                        >
                            <MenuIcon />
                        </IconButton>
                    </Grid>
                    <Grid item xs></Grid>
                    <Grid container item xs justifyContent="flex-end">
                        <MenuSimples />
                    </Grid>
                </Grid>
            </Toolbar>
        </AppBar>
    );
};
