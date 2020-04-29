import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container'
import MediaControlCard from './MediaControlCard';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Typography from '@material-ui/core/Typography';

const axios = require('axios');

const useStyles = makeStyles((theme) => ({
    container: {
        margin: theme.spacing(2),
    },
    div: {
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
    },
    filter: {
        display: 'flex',
        flexDirection: 'row',
        justifyContent: 'space-around',
        margin: theme.spacing(2),
    },
    button: {
        backgroundColor: '#817CC1',
        marginLeft: theme.spacing(2),
        color: '#FFFFFF',
        padding: '6px 40px',
    },
    textField: {
        marginLeft: theme.spacing(2),
        height: theme.spacing(0),
        backgroundColor: 'white',
    },
    title: {
        marginTop: theme.spacing(4),
    },
}));

export default function ListSongs() {
    const classes = useStyles();
    const [items, setItems] = useState([]);
    const [filterName, setFilterName] = useState('');
    const [filterArtist, setFilterArtist] = useState('');

    useEffect(() => {
        axios.get('http://localhost:64363/api/Song')
            .then(res => {
                console.log(res);
                setItems(res.data);
            })
            .catch(err => {
                console.log(err)
            })
    }, []);

    const handleFilterNameChange = (event) => {
        setFilterName(event.target.value);
    }

    const handleFirterArtistChange = (event) => {
        setFilterArtist(event.target.value);
    }

    const clearFilterFields = () => {
        const inputName = document.getElementById("name");
        inputName.value = '';

        const inputArtist = document.getElementById("artist");
        inputArtist.value = '';
    }

    const handleSongSearch = () => {
        if (filterName === '' && filterArtist === '') {
            axios.get('http://localhost:64363/api/Song')
                .then(res => {
                    console.log(res);
                    setItems(res.data);
                })
                .catch(err => {
                    console.log(err)
                });

            return;
        }

        axios.get(`http://localhost:64363/api/Song/filter?name=${filterName}&artist=${filterArtist}`)
            .then(res => {
                console.log(res);
                setItems(res.data);
            })
            .catch(err => {
                console.log(err)
            });
    }

    const clearFilter = () => {
        axios.get('http://localhost:64363/api/Song')
            .then(res => {
                console.log(res);
                setItems(res.data);
                clearFilterFields();
            })
            .catch(err => {
                console.log(err)
            });
    }

    return (
        <div className={classes.div}>
            <Typography margin="normal" variant="h4" className={classes.title}> My songs </Typography>
            <div className={classes.filter}>
                <TextField className={classes.textField} type="search" size="small" fullWidth id="name" label="Name" variant="outlined" onChange={handleFilterNameChange} />
                <TextField className={classes.textField} type="search" size="small" fullWidth id="artist" label="Artist" variant="outlined" onChange={handleFirterArtistChange} />
                <Button className={classes.button} variant="contained" color="primary" type="submit" onClick={handleSongSearch}>Search</Button>
                <Button className={classes.button} variant="contained" color="primary" type="submit" onClick={clearFilter}>Clear</Button>
            </div>
            <Container maxWidth="md" className={classes.container} >
                {items.map(item => (
                    <MediaControlCard name={item.name} artist={item.artist} />
                ))}
            </Container>
        </div>
    );
}