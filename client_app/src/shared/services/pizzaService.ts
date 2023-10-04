import axios from "axios";
import { PizzaOrderRequestDto } from "../types/pizzaOrderRequestDto";
import { PizzaOrderResponseDto } from "../types/pizzaOrderResponseDto";
import { PizzaSize } from "../types/pizzaSize";
import { Topping } from "../types/topping";

const BASE_URL = "http://localhost:5000/api/v1/orders";
const pizzaService = {
  getPizzaSizes: () => axios.get<PizzaSize[]>(`${BASE_URL}/available-sizes`),
  getPizzaToppings: () => axios.get<Topping[]>(`${BASE_URL}/available-toppings`),
  placeOrder: (orderDto: PizzaOrderRequestDto) => axios.post<PizzaOrderResponseDto>(BASE_URL, orderDto),
  getAllOrders: () => axios.get<PizzaOrderResponseDto[]>(BASE_URL),
  getOrderById: (id: number) => axios.get<PizzaOrderResponseDto>(`${BASE_URL}/${id}`),
  calculateCost: (orderDto: PizzaOrderRequestDto) => axios.post(`${BASE_URL}/calculate-cost`, orderDto),
  getPlacedOrders: () => axios.get<PizzaOrderResponseDto[]>(`${BASE_URL}`)
};

export default pizzaService;