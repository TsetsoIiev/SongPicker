import { createMuiTheme, responsiveFontSizes } from '@material-ui/core/styles';


let theme= createMuiTheme ({
    palette: {
        primary: {
            main: '#817CC1'
        },
        secondary: {
            main: '#ffffff'
        },
    },
    overrides: {
        MuiPaper: {
            root: {
                padding: '0 10px',
            }
        },
        MuiDialog: {
            paper: {
                padding: '10px 20px',
            }
        }
    }
})

theme= responsiveFontSizes(theme);

export default theme;