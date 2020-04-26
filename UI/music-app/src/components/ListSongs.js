import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container'
import MediaControlCard from './MediaControlCard';

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
    }
}));

export default function ListSongs() {
    const classes = useStyles();
    const [items, setItems] = useState([]);

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

    return (
        <div className={classes.div}>
            <Container maxWidth="md" className={classes.container} >
                {items.map(item => (
                <MediaControlCard name={item.name} artist={item.artist}/>
                ))}
            </Container>
        </div>
    );
}