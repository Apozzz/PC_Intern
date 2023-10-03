import { createAsyncThunk } from "@reduxjs/toolkit";
import pizzaService from "../../../shared/services/pizzaService";
import { PizzaOrderRequestDto } from "../../../shared/types/pizzaOrderRequestDto";
import { toastr } from 'react-redux-toastr';

export const fetchPizzaSizes = createAsyncThunk(
  "pizza/fetchSizes",
  async (_, { rejectWithValue }) => {
    try {
      const response = await pizzaService.getPizzaSizes();
      return response.data;
    } catch (error) {
      return rejectWithValue({ message: (error as Error).message });
    }
  }
);

export const fetchPizzaToppings = createAsyncThunk(
  "pizza/fetchToppings",
  async (_, { rejectWithValue }) => {
    try {
      const response = await pizzaService.getPizzaToppings();
      return response.data;
    } catch (error) {
      return rejectWithValue({ message: (error as Error).message });
    }
  }
);

export const placePizzaOrder = createAsyncThunk(
  "pizza/placeOrder",
  async (orderDto: PizzaOrderRequestDto, { rejectWithValue }) => {
    try {
      const response = await pizzaService.placeOrder(orderDto);
      toastr.success('Success', 'Order was placed successfully!');
      return response.data;
    } catch (error) {
      toastr.error('Error', 'Failed to place an order.');
      return rejectWithValue({ message: (error as Error).message });
    }
  }
);

export const fetchAllOrders = createAsyncThunk(
  "pizza/fetchAllOrders",
  async (_, { rejectWithValue }) => {
    try {
      const response = await pizzaService.getAllOrders();
      return response.data;
    } catch (error) {
      return rejectWithValue({ message: (error as Error).message });
    }
  },
);
export const fetchTotalCost = createAsyncThunk(
  "pizza/fetchTotalCost",
  async (orderDto: PizzaOrderRequestDto, { rejectWithValue }) => {
    try {
      const response = await pizzaService.calculateCost(orderDto);
      return response.data.totalCost;
    } catch (error) {
      return rejectWithValue({ message: (error as Error).message });
    }
  },
);