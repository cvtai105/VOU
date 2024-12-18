import React from 'react';
import Header from '../components/PlayerHeader';

import { Navigate, Outlet } from 'react-router-dom';
const PlayerLayout = () => {
    return (
        <>
            <Header />
            <Outlet />
        </>
    );
};

export default PlayerLayout;
