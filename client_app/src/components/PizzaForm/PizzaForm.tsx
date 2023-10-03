import React, { useEffect, useState } from 'react';
import { Button, FormControl, InputLabel, Select, MenuItem, FormGroup, FormControlLabel, Checkbox, Paper, Container, Typography, SelectChangeEvent, CircularProgress } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import styles from './PizzaForm.module.css';
import { AppDispatch, RootState } from '../../redux/store';
import { fetchPizzaSizes, fetchPizzaToppings, fetchTotalCost, placePizzaOrder } from '../../redux/slices/pizza/pizzaThunks';
import { PizzaOrderRequestDto } from '../../shared/types/pizzaOrderRequestDto';
import { toastr } from 'react-redux-toastr';

function PizzaForm() {
    const sizes = useSelector((state: RootState) => state.pizza.sizes);
    const toppings = useSelector((state: RootState) => state.pizza.toppings);
    const totalCost = useSelector((state: RootState) => state.pizza.totalCost);
    const loading = useSelector((state: RootState) => state.pizza.ongoingRequests > 0);

    const dispatch = useDispatch<AppDispatch>();
    const navigate = useNavigate();

    const [selectedSize, setSelectedSize] = useState<number | null>(null);
    const [selectedToppings, setSelectedToppings] = useState<number[]>([]);

    useEffect(() => {
        dispatch(fetchPizzaSizes());
        dispatch(fetchPizzaToppings());
    }, [dispatch]);

    useEffect(() => {
        if (selectedSize !== null || selectedToppings.length > 0) {
            const orderDto: PizzaOrderRequestDto = {
                sizeId: selectedSize ?? 0,
                toppingIds: selectedToppings
            };
            dispatch(fetchTotalCost(orderDto));
        }
    }, [selectedSize, selectedToppings, dispatch]);


    const handleSizeChange = (e: SelectChangeEvent<number>) => {
        setSelectedSize(e.target.value as number);
    };

    const handleToppingChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = Number(e.target.value);
        setSelectedToppings(prev => e.target.checked ? [...prev, value] : prev.filter(topping => topping !== value));
    };

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        if (selectedSize === null) {
            toastr.error('error', 'Pizza Size must be selected!');
            return;
        }

        const orderDto = {
            sizeId: selectedSize,
            toppingIds: selectedToppings
        };

        await dispatch(placePizzaOrder(orderDto));
        navigate('/order-list');
    };

    return (
        <Container maxWidth="sm" className={styles.formWrapper}>
            <Typography variant="h4" gutterBottom>Create Your Pizza</Typography>
            <Paper className={styles.formContainer} elevation={3}>
                {loading && (
                    <div className={styles.loadingOverlay}>
                        <CircularProgress />
                    </div>
                )}
                <form onSubmit={handleSubmit}>
                    <FormControl variant="outlined" className={styles.sizeDropdown}>
                        <InputLabel>Pizza Size</InputLabel>
                        <Select value={selectedSize || ""} onChange={handleSizeChange} label="Pizza Size">
                            {sizes.map(size => <MenuItem key={size.id} value={size.id}>{size.name}</MenuItem>)}
                        </Select>
                    </FormControl>
    
                    <Typography variant="h6">Toppings</Typography>
                    <FormGroup className={styles.toppingGroup}>
                        {toppings.map(topping => (
                            <FormControlLabel
                                key={topping.id}
                                control={<Checkbox value={topping.id} onChange={handleToppingChange} />}
                                label={topping.name}
                            />
                        ))}
                    </FormGroup>
    
                    <Typography variant="h6" className={styles.totalCost}>
                        Total Cost: {typeof totalCost === 'number' ? totalCost.toFixed(2) : 'Calculating...'}
                    </Typography>
    
                    <Button type="submit" variant="contained" color="primary" className={styles.orderButton}>Place Order</Button>
                </form>
            </Paper>
        </Container>
    );
    
}

export default PizzaForm;
