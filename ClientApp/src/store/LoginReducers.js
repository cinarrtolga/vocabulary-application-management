const loginSuccess = 'LOGIN_SUCCESS';
const loginFail = 'LOGIN_FAIL';
const initialState = { returnState: false };

export const loginActions = {
    getUserDetail: (username, password) => async (dispatch, getState) => {
        const url = `api/SampleData/Authentication?username=${username}&password=${password}`;
        const response = await fetch(url);
        const forecasts = await response.json();

        if (forecasts.success) {
            dispatch({ type: loginSuccess });
        } else {
            dispatch({ type: loginFail });
        }
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === loginSuccess) {
        return {
            ...state,
            returnState: true
        };
    }

    if (action.type === loginFail) {
        return {
            ...state,
            returnState: false
        };
    }

    return state;
};
