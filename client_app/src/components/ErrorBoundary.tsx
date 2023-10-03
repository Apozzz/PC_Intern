import { Component, ReactNode } from 'react';
import { ErrorBoundaryProps } from '../shared/types/errorBoundaryProps';
import { ErrorBoundaryState } from '../shared/types/errorBoundaryState';

class ErrorBoundary extends Component<ErrorBoundaryProps, ErrorBoundaryState> {
    state: ErrorBoundaryState = {
        hasError: false,
    };

    static getDerivedStateFromError(): ErrorBoundaryState {
        return { hasError: true };
    }

    render(): ReactNode {
        if (this.state.hasError) {
            return <h1>Something went wrong. Please refresh the page or try again later.</h1>;
        }

        return this.props.children;
    }
}

export default ErrorBoundary;