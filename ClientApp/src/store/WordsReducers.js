const page_load = 'PAGE_LOAD';
const get_words_list = 'GET_WORDS_LIST';
const new_word_window = 'NEW_WORD_WINDOW';
const new_word_insert = 'NEW_WORD_INSERT';
const get_word = 'GET_WORD';
const word_update = 'WORD_UPDATE';
const word_delete = 'WORD_DELETE';
const initialState = {
    loading: true,
    wordsList: [],
    showInsertModal: false,
    operationResult: false
};

export const wordActions = {
    getAllWords: () => (dispatch) => {
        const xhr = new XMLHttpRequest();
        xhr.open('post', 'api/word/getallwords', false);
        xhr.onload = () => {
            const result = JSON.parse(xhr.responseText);
            dispatch({ type: get_words_list, data: result.data });
        };
        xhr.send();
    },
    insertNewWord: (data) => (dispatch) => {
        const xhr = new XMLHttpRequest();
        xhr.open('post', 'api/word/newword', false);
        xhr.onload = () => {
            console.log(xhr.responseText);
        };
        xhr.send(data)

        dispatch({ type: new_word_insert });
    },
    getWordByWordId: (data) => (dispatch) => {
        const xhr = new XMLHttpRequest();
        xhr.open('post', 'api/word/getWordByWordId', false);
        xhr.onload = () => {
            console.log(xhr.responseText);
        }
        xhr.send(data);

        dispatch({ type: get_word });
    },
    updateWord: (data) => (dispatch) => {
        const xhr = new XMLHttpRequest();
        xhr.open('post', 'api/word/updateWord', false);
        xhr.onload = () => {
            console.log(xhr.responseText);
        };
        xhr.send(data);

        dispatch({ type: word_update });
    },
    deleteWord: (data) => (dispatch) => {
        const xhr = new XMLHttpRequest();
        xhr.open('post', 'api/word/deleteword', false);
        xhr.onload = () => {
            console.log(xhr.responseText);
        };
        xhr.send(data);

        dispatch({ type: word_delete });
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

    return state;
};
