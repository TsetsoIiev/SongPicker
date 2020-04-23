import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container'
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import IconButton from '@material-ui/core/IconButton';
import QueueMusicIcon from '@material-ui/icons/QueueMusic';

const useStyles = makeStyles((theme) => ({
    container: {
        backgroundColor: '#cfe8',
        height: '52vh',
        margin: theme.spacing(1),
    },
    div: {
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
    }
}));

export default function Create() {
    const classes = useStyles();

    return (
        <div className={classes.div}>
            <Typography variant="h5" gutterBottom align="left">
                My songs
            </Typography>
            <Container maxWidth="md" className={classes.container}>
            Something in the way..  
            </Container>
        </div>
    );
}