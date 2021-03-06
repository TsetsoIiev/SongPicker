import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Navigation from '../components/Navigation'
import AppInfo from '../components/AppInfo'
import ListSongs from '../components/ListSongs'

const useStyles = makeStyles((theme) => ({
    div: {
        display: 'block',
    }
}));

export default function HomePage() {
    const classes = useStyles();

    return (
        <div className={classes.root}>
            <Navigation />
            <div className={classes.div}>
                <AppInfo />
                <ListSongs />
            </div>
        </div>
    );
}