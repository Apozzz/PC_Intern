import './App.css'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './components/Navbar/Navbar'
import PizzaForm from './components/PizzaForm/PizzaForm'
import OrderList from './components/OrderList/OrderList';
import { Provider } from 'react-redux';
import store from './redux/store';
import ReduxToastr from 'react-redux-toastr';
import ErrorBoundary from './components/ErrorBoundary';

function App() {
  return (
    <ErrorBoundary>
      <Provider store={store}>
        <Router>
          <Navbar />
          <Routes>
            <Route path="/create-pizza" element={<PizzaForm />} />
            <Route path="/order-list" element={<OrderList />} />
          </Routes>
        </Router>
        <ReduxToastr
          timeOut={4000}
          newestOnTop={false}
          preventDuplicates
          position="top-right"
          transitionIn="fadeIn"
          transitionOut="fadeOut"
          progressBar
          closeOnToastrClick
        />
      </Provider>
    </ErrorBoundary>

  )
}

export default App;