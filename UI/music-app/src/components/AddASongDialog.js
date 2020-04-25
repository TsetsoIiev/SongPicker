import React, { useState } from 'react';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import DialogTitle from '@material-ui/core/DialogTitle';
import Dialog from '@material-ui/core/Dialog';
import Typography from '@material-ui/core/Typography';
import TextField from '@material-ui/core/TextField';
import List from '@material-ui/core/List';

const axios = require('axios');

function SimpleDialog(props) {
    const { onClose, selectedValue, open } = props;
    const [name, setName] = useState('');
    const [artist, setArtist] = useState('');
    const [album, setAlbum] = useState('');
    const [genre, setGenre] = useState('');
    const [year, setYear] = useState(0);

    const handleNameChange = (event) => {
        setName(event.target.value);
    }

    const handleArtistChange = (event) => {
        setArtist(event.target.value);
    }

    const handleAlbumChange = (event) => {
        setAlbum(event.target.value);
    }

    const handleGenreChange = (event) => {
        setGenre(event.target.value);
    }

    const handleYearChange = (event) => {
        setYear(event.target.value);
    }

    const handleAddASongFormSubmit = () => {
        var data = JSON.stringify({
            name: name,
            artist: artist,
            album: album,
            genre: genre,
            year: year
        });

        let axiosConfig = {
            headers: {
                'Content-Type': 'application/json;charset=UTF-8',
                "Access-Control-Allow-Origin": "*",
            }
          };

          const body = JSON.stringify({ name, artist, album, genre, year });

        axios.post('http://localhost:64363/api/Song', body, axiosConfig)
        .then( response  => console.log(response))
        .catch( error => console.log(error));
    };

    return (
        <Dialog open={open} maxWidth="sm">
            <DialogTitle id="simple-dialog-title">Add A Song</DialogTitle>
            <form onSubmit={handleAddASongFormSubmit} >
                <TextField fullWidth required margin="dense" id="name" label="Name" variant="outlined" onChange={handleNameChange} />
                <TextField fullWidth required margin="dense" id="artist" label="Artist" variant="outlined" onChange={handleArtistChange} />
                <TextField fullWidth required margin="dense" id="album" label="Album" variant="outlined" onChange={handleAlbumChange} />
                <TextField fullWidth required margin="dense" id="genre" label="Genre" variant="outlined" onChange={handleGenreChange} />
                <TextField fullWidth required margin="dense" id="year" label="Year" variant="outlined" onChange={handleYearChange} />
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