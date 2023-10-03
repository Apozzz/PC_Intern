import { useEffect } from 'react';
import { Grid, Typography, Card, CardContent, CircularProgress } from '@mui/material';
import styles from './OrderList.module.css';
import { useDispatch, useSelector } from 'react-redux';
import { RootState, AppDispatch } from '../../redux/store';
import { fetchAllOrders } from '../../redux/slices/pizza/pizzaThunks';

function OrderList() {
    const dispatch = useDispatch<AppDispatch>();
    const orders = useSelector((state: RootState) => state.pizza.orders);
    const loading = useSelector((state: RootState) => state.pizza.loading);

    useEffect(() => {
        // Dispatch the thunk action to fetch all orders
        dispatch(fetchAllOrders());
    }, [dispatch]);

    return (
        <div>
            {loading ? <CircularProgress /> : (
                <div className={styles.orderListContainer}>
                    <Typography variant="h4" gutterBottom component="div">
                        Order List
                    </Typography>

                    <Grid container spacing={3}>
                        {orders.map(order => (
                            <Grid item key={order.id} xs={12} sm={6} md={4}>
                                <Card className={styles.orderCard}>
                                    <CardContent>
                                        <Typography variant="h6" component="div">
                                            Size: {order.sizeName}
                                        </Typography>
                                        <Typography variant="body1" component="div">
                                            Total Cost: {order.totalCost.toFixed(2)}
                                        </Typography>
                                        <Typography variant="body1" component="div">
                                            Toppings: {order.toppingNames.length > 0 ? order.toppingNames.join(', ') : 'None'}
                                        </Typography>
                                    </CardContent>
                                </Card>
                            </Grid>
                        ))}
                    </Grid>
                </div>
            )}
        </div>

    );
}

export default OrderList;
