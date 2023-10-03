import { PizzaOrderResponseDto } from "./pizzaOrderResponseDto";
import { PizzaSize } from "./pizzaSize";
import { Topping } from "./topping";

export interface PizzaState {
    sizes: PizzaSize[];
    toppings: Topping[];
    orders: PizzaOrderResponseDto[];
    totalCost: number;
    loading: boolean;
    error: string;
    ongoingRequests: number;
  }