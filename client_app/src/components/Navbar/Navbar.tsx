import { Link as RouterLink } from 'react-router-dom';
import { AppBar, Toolbar, Typography, Button, Link } from '@mui/material';
import './Navbar.module.css';  // Changed from .module.css to .css

function Navbar() {
  return (
    <AppBar position="fixed" color="default">
      <Toolbar className="navbar-toolbar">
        <Typography variant="h6" className="navbar-title">
          Pizza Maker
        </Typography>
        <div>
          <Link component={RouterLink} to="/create-pizza" color="inherit" className="navbar-link">
            <Button color="inherit">Create Pizza</Button>
          </Link>
          <Link component={RouterLink} to="/order-list" color="inherit" className="navbar-link">
            <Button color="inherit">Order List</Button>
          </Link>
        </div>
      </Toolbar>
    </AppBar>
  );
}

export default Navbar;