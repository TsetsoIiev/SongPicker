import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container'
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import AddASongDialog from './AddASongDialog';

const useStyles = makeStyles((theme) => ({
    container: {
        marginTop: theme.spacing(6),
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
    },
    menuButton: {
        marginRight: theme.spacing(2),
    },
    title: {
        flexGrow: 1,
    },
    div: {
        display: 'flex',
    },
    button: {
        backgroundColor: '#817CC1',
        marginLeft: theme.spacing(2),
        color: '#FFFFFF'
    }
}));

export default function AppInfo() {
    const classes = useStyles();

    return (
        <Container maxWidth="sm" className={classes.container}>
            <Typography variant="h3" align="center" gutterBottom>
                Music for everyone.
                </Typography>
            <Typography variant="h6" align="center" gutterBottom>
                Add songs, create playlists and maybe in the distant future do even more.
                </Typography>
                <div className={classes.div}>
                <AddASongDialog/>
                <Button variant="contained" className={classes.button}> Create a playlist </Button>
                </div>
        </Container>
    );
}