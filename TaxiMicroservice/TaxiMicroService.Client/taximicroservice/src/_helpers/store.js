import { createStore, applyMiddleware } from 'redux';
import thunkMiddleware from 'redux-thunk';
import { createLogger } from 'redux-logger';
import {users}  from '../_reducers/users.reducer';
import {authentication}  from '../_reducers/authentication.reducer';
import {registration}  from '../_reducers/registration.reducer';

//import userReducer from '../_reducers/users.reducer';
//import registrationReducer from '../_reducers/registration.reducer';
//import authenticationReducer from '../_reducers/authentication.reducer';

const loggerMiddleware = createLogger();

export const store = createStore(
    users,
    authentication,
    registration,
   // userReducer,
    //registrationReducer,
   // authenticationReducer,
    applyMiddleware(
        thunkMiddleware,
        loggerMiddleware
    )
);