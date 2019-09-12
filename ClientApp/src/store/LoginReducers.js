const loginSuccess = 'LOGIN_SUCCESS';
const loginFail = 'LOGIN_FAIL';
const initialState = { returnState: false, loginControl: false };

export const loginActions = {
    getUserDetail: (username, password) => async (dispatch, getState) => {
        const request = new FormData();
        request.append('Username', username);
        request.append('Password', password);

        const xhr = new XMLHttpRequest();
        xhr.open('post', "api/Login/Authentication", true);

        xhr.onload = function (e) {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    var result = JSON.parse(xhr.response)
                    if (result.success) {
                        console.log("Başarılı!");
                    }
                } else {
                    console.error(xhr.statusText)
                }
            }
        }.bind(this)

        xhr.onerror = function (e) {
            console.error(xhr.statusText)
        }

        xhr.send(request);
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === loginSuccess) {
        return {
            ...state,
            returnState: true,
            loginControl: true
        };
    }

    if (action.type === loginFail) {
        return {
            ...state,
            returnState: false,
            loginControl: false
        };
    }

    return state;
};
