import React, { useState, useEffect } from 'react';
import { makeStyles, useTheme } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import IconButton from '@material-ui/core/IconButton';
import Typography from '@material-ui/core/Typography';
import SkipPreviousIcon from '@material-ui/icons/SkipPrevious';
import PlayArrowIcon from '@material-ui/icons/PlayArrow';
import SkipNextIcon from '@material-ui/icons/SkipNext';
import itunesImg from '../images/tune.png'
import useMediaQuery from '@material-ui/core/useMediaQuery';

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
        justifyContent: 'space-evenly',
        flexDirection: 'row',
        margin: theme.spacing(1),
    },
    content: {
        flex: '1 0 auto',
    },
    cover: {
        width: 55,
    },
    controls: {
        display: 'flex',
        alignItems: 'center',
        paddingLeft: theme.spacing(1),
        paddingBottom: theme.spacing(1),
    },
    playIcon: {
        height: 38,
        width: 38,
    },
}));

export default function MediaControlCard(props) {
    const classes = useStyles();
    const theme = useTheme();

    const matchesMobile = useMediaQuery(theme.breakpoints.down('sm'));
    const matchesDesktop = useMediaQuery(theme.breakpoints.up('md'));

    return (
        <Card className={classes.root}>
            { 
            matchesDesktop ? 
            (<CardMedia
                className={classes.cover}
                image={itunesImg}
                title="img"
            />) : ( <div> </div> )
             }
            <CardContent className={classes.content}>
                <Typography component="h5" variant="h5">
                    {props.name}
                </Typography>
                <Typography variant="subtitle1" color="textSecondary">
                    {props.artist}
                </Typography>
            </CardContent>
            <div className={classes.controls}>
                <IconButton aria-label="previous">
                    {theme.direction === 'rtl' ? <SkipNextIcon /> : <SkipPreviousIcon />}
                </IconButton>
                <IconButton aria-label="play/pause">
                    <PlayArrowIcon className={classes.playIcon} />
                </IconButton>
                <IconButton aria-label="next">
                    {theme.direction === 'rtl' ? <SkipPreviousIcon /> : <SkipNextIcon />}
                </IconButton>
            </div>
        </Card>
    );
}