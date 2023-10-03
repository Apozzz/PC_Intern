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
// const BASE_URL = "http://localhost:5000/api/v1/orders";

// const pizzaService = {
//   async getPizzaSizes(): Promise<PizzaSize[]> {
//     try {
//       const response = await axios.get<PizzaSize[]>(
//         `${BASE_URL}/available-sizes`
//       );
//       return response.data;
//     } catch (error) {
//       console.error("Failed to fetch pizza sizes:", error);
//       throw error;
//     }
//   },

//   async getPizzaToppings(): Promise<Topping[]> {
//     try {
//       const response = await axios.get<Topping[]>(
//         `${BASE_URL}/available-toppings`
//       );
//       return response.data;
//     } catch (error) {
//       console.error("Failed to fetch pizza toppings:", error);
//       throw error;
//     }
//   },

//   async placeOrder(
//     orderDto: PizzaOrderRequestDto
//   ): Promise<PizzaOrderResponseDto> {
//     try {
//       const response = await axios.post<PizzaOrderResponseDto>(
//         BASE_URL,
//         orderDto
//       );
//       return response.data;
//     } catch (error) {
//       console.error("Failed to place order:", error);
//       throw error;
//     }
//   },

//   async getAllOrders(): Promise<PizzaOrderResponseDto[]> {
//     try {
//       const response = await axios.get<PizzaOrderResponseDto[]>(BASE_URL);
//       return response.data;
//     } catch (error) {
//       console.error("Failed to get all orders:", error);
//       throw error;
//     }
//   },

//   async getOrderById(id: number): Promise<PizzaOrderResponseDto> {
//     try {
//       const response = await axios.get<PizzaOrderResponseDto>(
//         `${BASE_URL}/${id}`
//       );
//       return response.data;
//     } catch (error) {
//       console.error(`Failed to get order by ID (${id}):`, error);
//       throw error;
//     }
//   },

//   async calculateCost(orderDto: PizzaOrderRequestDto): Promise<number> {
//     try {
//       const response = await axios.post(`${BASE_URL}/calculate-cost`, orderDto);
//       return response.data.totalCost;
//     } catch (error) {
//       console.error("Failed to calculate cost:", error);
//       throw error;
//     }
//   },

//   async getPlacedOrders(): Promise<PizzaOrderResponseDto[]> {
//     try {
//       const response = await axios.get(`${BASE_URL}`);
//       return response.data;
//     } catch (error) {
//       console.error("Failed to fetch orders:", error);
//       throw error;
//     }
//   },
// };

// export default pizzaService;
