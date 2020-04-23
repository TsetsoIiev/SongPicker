import React, {useState} from 'react';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import DialogTitle from '@material-ui/core/DialogTitle';
import Dialog from '@material-ui/core/Dialog';
import Typography from '@material-ui/core/Typography';
import TextField from '@material-ui/core/TextField';
import List from '@material-ui/core/List';

// const useStyles = makeStyles({
// });

function SimpleDialog(props) {
    //const classes = useStyles();
    const { onClose, selectedValue, open } = props;

    const handleAddASongFormSubmit = (data) => {
        var xhr = new XMLHttpRequest();

        console.log(data);
        xhr.send(JSON.stringify(data));
        xhr.open('POST', 'localhost:44372');
    };

    return (
        <Dialog  open={open} maxWidth="sm">
            <DialogTitle id="simple-dialog-title">Add A Song</DialogTitle>
            <form onSubmit={handleAddASongFormSubmit} action="localhost:4" method="POST">
                <TextField fullWidth required margin="dense" id="name" label="Name" variant="outlined" />
                <TextField fullWidth required margin="dense" id="artist" label="Artist" variant="outlined" />
                <TextField fullWidth required margin="dense" id="album" label="Album" variant="outlined" />
                <TextField fullWidth required margin="dense" id="genre" label="Genre" variant="outlined" />
                <TextField fullWidth required margin="dense" id="year" label="Year" variant="outlined" />
                <List>
                    <Button variant="contained" color="primary" type="submit">Ok</Button>
                    <Button variant="contained">Cancel</Button>
                </List>
            </form>
        </Dialog>
    );
}

export default function SimpleDialogDemo() {
    const [open, setOpen] = useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    return (
        <div>
            <Button variant="outlined" onClick={handleClickOpen}>
                Add A Song
      </Button>
            <SimpleDialog open={open} onClose={handleClose} />
        </div>
    );
}