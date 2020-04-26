import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container'
import MediaControlCard from './MediaControlCard';

const axios = require('axios');

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
    useEffect(() => {
        getSongs().then(setSongs);
    }, []);
    
    const classes = useStyles();

    const [items, setItems] = useState([]);

    const getSongs = async () => {
        try {
            const response = await axios.get('http://localhost:64363/api/Song');
            const data = response.data;
            return data;
        } catch (error) {
            console.log(error);
        }
    }

    const setSongs = (data) => {
        data.map((item) => {
            items.push(item);
        });
    }

    return (
        <div className={classes.div}>
            <Container maxWidth="md" className={classes.container} >
                {items.map((item) => (<MediaControlCard />))}
            </Container>
        </div>
    );
}