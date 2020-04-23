import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import IconButton from '@material-ui/core/IconButton';
import QueueMusicIcon from '@material-ui/icons/QueueMusic';

const useStyles = makeStyles((theme) => ({
  title: {
    flexGrow: 1,
  },
  
}));

export default function Navigation() {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <AppBar position="static" style={{ backgroundColor: '#817CC1'}}>
        <Toolbar>
          <IconButton edge="start" className={classes.menuButton} color="inherit" aria-label="menu">
            <QueueMusicIcon/>
          </IconButton>
          <Typography variant="h6" className={classes.title}>
            SongPicker
          </Typography>
          <Button color="inherit">Help</Button>
          <Button color="inherit">Info</Button>
        </Toolbar>
      </AppBar>
    </div>
  );
}