import { configureStore } from '@reduxjs/toolkit';
import pizzaReducer from './slices/pizza/pizzaSlice';
import { reducer as toastrReducer } from 'react-redux-toastr';

const store = configureStore({
  reducer: {
    pizza: pizzaReducer,
    toastr: toastrReducer
  },
});

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;