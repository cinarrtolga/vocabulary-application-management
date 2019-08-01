const page_load = 'PAGE_LOAD';
const get_words_list = 'GET_WORDS_LIST';
const new_word_window = 'NEW_WORD_WINDOW';
const new_word_insert = 'NEW_WORD_INSERT';
const word_update = 'WORD_UPDATE';
const word_delete = 'WORD_DELETE';
const operation_success = 'OPERATION_SUCCESS';
const operation_false = 'OPERATION_FALSE';
const operation_reset = 'OPERATION_RESET';
const initialState = {
    loading: true,
    wordsList: [],
    showInsertModal: false,
    operationResult: false,
    operationSuccess: false,
    operationFail: false
};

export const wordActions = {
    getAllWords: () => (dispatch) => {
        const xhr = new XMLHttpRequest();
        xhr.open('post', 'api/word/getallwords', true);
        xhr.onload = () => {
            const result = JSON.parse(xhr.responseText);
            dispatch({ type: get_words_list, data: result.data.success });
        };
        xhr.send(null);
    },
    insertNewWord: (data) => (dispatch) => {
        const xhr = new XMLHttpRequest();
        xhr.open('post', 'api/word/newword', true);
        xhr.onload = () => {
            const result = JSON.parse(xhr.responseText);
            if(result){
                dispatch({ type: operation_success });
            }else {
                dispatch({ type: operation_false });
            }
        };
        xhr.send(data)

        dispatch({ type: new_word_insert });
    },
    updateWord: (data) => (dispatch) => {
        const xhr = new XMLHttpRequest();
        xhr.open('post', 'api/word/updateWord', true);
        xhr.onload = () => {
            const result = JSON.parse(xhr.responseText);
            if(result){
                dispatch({ type: operation_success });
            }else {
                dispatch({ type: operation_false });
            }
        };
        xhr.send(data);

        dispatch({ type: word_update });
    },
    deleteWord: (data) => (dispatch) => {
        const xhr = new XMLHttpRequest();
        xhr.open('post', 'api/word/deleteword', true);
        xhr.onload = () => {
            const result = JSON.parse(xhr.responseText);
            if(result){
                dispatch({ type: operation_success });
            }else {
                dispatch({ type: operation_false });
            }
        };
        xhr.send(data);

        dispatch({ type: word_delete });
    },
    resetOperations: () => (dispatch) => {
        dispatch({ type: operation_reset });
    }
};

export const reducer = (state, action) => {
    state = state || initialState

    if (action.type === page_load) {
        return {
            ...state,
            loading: true
        };
    }

    if (action.type === get_words_list) {
        return {
            ...state,
            loading: false,
            wordsList: action.data
        };
    }

    if (action.type === new_word_window) {
        return {
            ...state,
            showInsertModal: true
        };
    }

    if (action.type === new_word_insert) {
        return {
            ...state,
            operationResult: action.result
        };
    }

    if (action.type === word_update) {
        return {
            ...state,
            operationResult: action.result
        }
    }

    if (action.type === word_delete) {
        return {
            ...state,
            operationResult: action.result
        }
    }

    if (action.type === operation_success) {
        return {
            ...state,
            operationSuccess: true
        }
    }

    if (action.type === operation_false) {
        return {
            ...state,
            operationFail: true
        }
    }

    if(action.type === operation_reset){
        return {
            ...state,
            operationSuccess: false,
            operationFail: false
        }
    }

    return state;
};
