import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { PizzaState } from "../../../shared/types/pizzaState";
import { PizzaOrderResponseDto } from "../../../shared/types/pizzaOrderResponseDto";
import { PizzaSize } from "../../../shared/types/pizzaSize";
import { Topping } from "../../../shared/types/topping";
import { fetchPizzaSizes, fetchPizzaToppings, fetchAllOrders, placePizzaOrder, fetchTotalCost } from "./pizzaThunks";

const initialState: PizzaState = {
  sizes: [],
  toppings: [],
  orders: [],
  totalCost: 0,
  loading: false,
  error: "",
  ongoingRequests: 0,
};

const pizzaSlice = createSlice({
  name: "pizza",
  initialState,
  reducers: {
    setSizes: (state, action: PayloadAction<PizzaSize[]>) => {
      state.sizes = action.payload;
    },
    setToppings: (state, action: PayloadAction<Topping[]>) => {
      state.toppings = action.payload;
    },
    addOrder: (state, action: PayloadAction<PizzaOrderResponseDto>) => {
      state.orders.push(action.payload);
    },
    setTotalCost: (state, action: PayloadAction<number>) => {
      state.totalCost = action.payload;
    },
    setOrders: (state, action: PayloadAction<PizzaOrderResponseDto[]>) => {
      state.orders = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(fetchPizzaSizes.fulfilled, (state, action) => {
        state.sizes = action.payload;
        state.ongoingRequests -= 1;
      })
      .addCase(fetchPizzaSizes.pending, (state) => {
        state.ongoingRequests += 1;
      })
      .addCase(fetchPizzaSizes.rejected, (state, action) => {
        state.ongoingRequests -= 1;
        state.error = action.error.message || "An error occurred";
      })
      .addCase(fetchPizzaToppings.fulfilled, (state, action) => {
        state.toppings = action.payload;
        state.ongoingRequests -= 1;
      })
      .addCase(fetchPizzaToppings.pending, (state) => {
        state.ongoingRequests += 1;
      })
      .addCase(fetchPizzaToppings.rejected, (state, action) => {
        state.ongoingRequests -= 1;
        state.error = action.error.message || "An error occurred";
      })
      .addCase(fetchAllOrders.fulfilled, (state, action) => {
        state.orders = action.payload;
        state.loading = false;
      })
      .addCase(fetchAllOrders.pending, (state) => {
        state.loading = true;
      })
      .addCase(fetchAllOrders.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || "An error occurred";
      })
      .addCase(placePizzaOrder.fulfilled, (state, action) => {
        state.orders.push(action.payload);
        state.loading = false;
      })
      .addCase(placePizzaOrder.pending, (state) => {
        state.loading = true;
      })
      .addCase(placePizzaOrder.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || "Failed to place the order";
      })
      .addCase(fetchTotalCost.fulfilled, (state, action) => {
        state.totalCost = action.payload;
        state.loading = false;
      })
      .addCase(fetchTotalCost.pending, (state) => {
        state.loading = true;
      })
      .addCase(fetchTotalCost.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || "Failed to place the order";
      });
  },
});

export const { setSizes, setToppings, addOrder, setTotalCost, setOrders } =
  pizzaSlice.actions;
export default pizzaSlice.reducer;
