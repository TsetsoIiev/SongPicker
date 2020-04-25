import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container'
import MediaControlCard from './MediaControlCard';

const useStyles = makeStyles((theme) => ({
    container: {
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
            <Container maxWidth="md" className={classes.container}>
                <MediaControlCard />
            </Container>
        </div>
    );
}