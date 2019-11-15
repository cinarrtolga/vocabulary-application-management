import React, { Component } from 'react';
import {
    Container,
    Row,
    Table,
    Alert,
    Fade,
    Button,
    ButtonGroup,
    Modal,
    ModalHeader,
    ModalBody,
    ModalFooter,
    Form,
    FormGroup,
    Input
} from 'reactstrap';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { wordActions } from '../store/WordsReducers';
import '../Style/WordPageStyle.css';

class WordsPage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            fadeIn: true,
            updateModal: false,
            removeModal: false,
            insertModal: false,
            keyword: '',
            mean: '',
            version: 0,
            operationalItem: null
        };
    }

    componentWillMount() {
        this.props.checkLogin();

        console.log(this.props.loginCheckStatus);

        if (!this.props.loginCheckStatus) {
            this.props.getAllWords();
            this.forceUpdate();
        }
    }

    //////////
    //Update Button Click Method.
    //Working with word item.
    //This button trigger to redux action.
    /////////
    //#region
    btnWordUpdate = (item) => {
        this.props.updateWord(item);
    }
    //#endregion

    //////////
    //Delete Button Click Method.
    //Working with word item.
    //This button trigger to redux action.
    /////////
    //#region
    btnWordDelete = (item) => {
        this.props.deleteWord(item);
    }
    //#endregion

    //////////
    //Insert button click method
    //This action trigger to redux action
    //////////
    //#region
    btnWordInsert = () => {
        const data = new FormData();
        data.append("Keyword", this.state.keyword);
        data.append("Mean", this.state.mean);
        data.append("Version", this.state.version);
        data.append("Status", true);

        console.log(data);

        this.props.insertNewWord(data);

        setTimeout(() => {
            this.resetOperations();
        }, 10000);
    }
    //#endregion

    //////////
    //This method for reset operation modals
    //////////
    //#region
    resetOperations = () => {
        this.props.resetOperations();
        this.closeModalPopUp('updateModal');
        this.closeModalPopUp('deleteModal');
        this.closeModalPopUp('insertModal');
    }
    //#endregion

    //////////
    //Update operation button
    //It's different from Click Button
    //This is using for update in database.
    //////////
    //#region
    updateOperation = () => {
        this.setState({
            operationalItem: {
                keyword: this.state.keyword,
                mean: this.state.mean,
                version: this.state.version
            }
        });
    }
    //#endregion

    //////////
    //Pop-up open method.
    //It's working with item and pop-up type.
    //Pop-up type is state name.
    //////////
    //#region
    getModalPopUp = (item, type) => {
        this.setState({
            [type]: true,
            keyword: item.keyword,
            mean: item.mean,
            version: item.version,
            operationalItem: item
        });
    }
    //#endregion

    //////////
    //Pop-up close method.
    //It's working with item and pop-up type.
    //Pop-up type is state name.
    /////////
    //#region
    closeModalPopUp = (type) => {
        this.setState({
            [type]: false
        });
    }
    //#endregion

    //////////
    //Word update pop-up.
    //Working with state.
    //////////
    //#region
    WordOperationModal = () => {
        return (
            <Modal isOpen={this.state.updateModal} toggle={this.closeModalPopUp.bind(this, 'updateModal')}>
                <ModalHeader toggle={this.closeModalPopUp.bind(this, 'updateModal')}>Updating {this.state.keyword}</ModalHeader>
                <ModalBody>
                    <Form>
                        <FormGroup>
                            <Input
                                type='text'
                                className='form-control'
                                placeholder='Keyword'
                                value={this.state.keyword}
                                onChange={e => this.setState({ keyword: e.target.value })}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Input
                                type='text'
                                className='form-control'
                                placeholder='Mean'
                                value={this.state.mean}
                                onChange={e => this.setState({ mean: e.target.value })}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Input
                                type='text'
                                className='form-control'
                                placeholder='Version'
                                value={this.state.version}
                                onChange={e => this.setState({ version: e.target.value })}
                            />
                        </FormGroup>
                    </Form>
                </ModalBody>
                <ModalFooter>
                    <Button color="primary" onClick={this.btnWordUpdate.bind(this, this.state.operationalItem)}>Insert</Button>
                    <Button color="secondary" onClick={this.closeModalPopUp.bind(this, 'insertModal')}>Cancel</Button>
                </ModalFooter>
            </Modal>
        );
    }
    //#endregion

    //////////
    //Word remove pop-up
    //Working with state.
    //////////
    //#region
    WordDeleteModal = () => {
        return (
            <Modal isOpen={this.state.removeModal} toggle={this.closeModalPopUp.bind(this, 'removeModal')}>
                <ModalHeader toggle={this.closeModalPopUp.bind(this, 'removeModal')}>Removing {this.state.keyword}</ModalHeader>
                <ModalBody>
                    If you click remove button, you will delete this word. Are you sure?
                </ModalBody>
                <ModalFooter>
                    <Button color="primary" onClick={this.btnWordDelete.bind(this, this.state.operationalItem)}>Remove</Button>{' '}
                    <Button color="secondary" onClick={this.closeModalPopUp.bind(this, 'removeModal')}>Cancel</Button>
                </ModalFooter>
            </Modal>
        );
    }
    //#endregion

    //////////
    //Insert New Word
    //Using state for insert
    //////////
    //#region
    InsertNewWordModal = () => {
        return (
            <Modal isOpen={this.state.insertModal} toggle={this.closeModalPopUp.bind(this, 'insertModal')}>
                <ModalHeader toggle={this.closeModalPopUp.bind(this, 'insertModal')}>Insert New Word</ModalHeader>
                <ModalBody>
                    <Form>
                        <FormGroup>
                            <Input
                                type='text'
                                className='form-control'
                                placeholder='Keyword'
                                value={this.state.keyword}
                                onChange={e => this.setState({ keyword: e.target.value })}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Input
                                type='text'
                                className='form-control'
                                placeholder='Mean'
                                value={this.state.mean}
                                onChange={e => this.setState({ mean: e.target.value })}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Input
                                type='text'
                                className='form-control'
                                placeholder='Version'
                                value={this.state.version}
                                onChange={e => this.setState({ version: e.target.value })}
                            />
                        </FormGroup>
                    </Form>
                </ModalBody>
                <ModalFooter>
                    <Button color="primary" onClick={this.btnWordInsert.bind(this, this.state.operationalItem)}>Insert</Button>
                    <Button color="secondary" onClick={this.closeModalPopUp.bind(this, 'insertModal')}>Cancel</Button>
                </ModalFooter>
            </Modal>
        );
    }
    //#endregion

    //////////
    //Success pop-up
    //Working with redux prop.
    //////////
    //#region
    OperationSuccessModal = () => {
        return (
            <Modal isOpen={this.props.operationSuccess} toggle={this.resetOperations.bind(this)}>
                <ModalHeader toggle={this.resetOperations.bind(this)}>Success</ModalHeader>
                <ModalBody>
                    You operation succeded
                </ModalBody>
            </Modal>
        );
    }
    //#endregion

    //////////
    //Error pop-up
    //Working with redux prop.
    //////////
    //#region
    OperationFailModal = () => {
        return (
            <Modal isOpen={this.props.operationFail} toggle={this.resetOperations.bind(this)}>
                <ModalHeader toggle={this.resetOperations.bind(this)}>Error</ModalHeader>
                <ModalBody>
                    You operation failed
                </ModalBody>
            </Modal>
        );
    }
    //#endregion

    //////////
    //Application words table.
    //Working With Word List.
    //Words are coming from redux and filling in componentWillMount method.
    /////////
    //#region 
    WordTables = () => {
        if (this.props.wordsList.length > 0) {
            return this.props.wordsList.map((item, i) => {
                return (
                    <tr key={i}>
                        <td>{item.id}</td>
                        <td>{item.keyword}</td>
                        <td>{item.mean}</td>
                        <td>{item.version}</td>
                        <td className="operation-column">
                            <ButtonGroup>
                                <Button
                                    onClick={this.getModalPopUp.bind(this, item, 'updateModal')}
                                >
                                    Update
                                </Button>
                                <Button
                                    onClick={this.getModalPopUp.bind(this, item, 'removeModal')}
                                >
                                    Remove
                                </Button>
                            </ButtonGroup>
                        </td>
                    </tr>
                );
            });
        }
    }
    //#endregion

    //////////
    //Page Load
    //////////
    //#region
    render() {
        if (!this.props.loading) {
            return (
                <Container>
                    <Row>
                        <Fade in={this.state.fadeIn} tag="h5" className="mt-3 table-page-description">
                            Vocabulary Application Word List
                        </Fade>
                        <div className='table-page-subDescription'>
                            <p>Vocabulary list as follows. You can create/update or remove any word in this page.</p>
                        </div>
                        <Container>
                            <div className='insert-buton-area'>
                                <Button
                                    onClick={this.getModalPopUp.bind(this, "", 'insertModal')}
                                >
                                    Insert New
                                </Button>
                            </div>
                        </Container>
                        <Table className='table table-bordered'>
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Keyword</th>
                                    <th>Mean</th>
                                    <th>Version</th>
                                    <th>Operations</th>
                                </tr>
                            </thead>
                            <tbody>
                                {this.WordTables()}
                            </tbody>
                        </Table>
                    </Row>
                    {this.WordOperationModal()}
                    {this.WordDeleteModal()}
                    {this.InsertNewWordModal()}
                    {this.OperationSuccessModal()}
                    {this.OperationFailModal()}
                </Container>
            );
        } else if (this.props.loginCheckStatus) {
            return (
                <Container>
                    <Row>
                        <Alert color="primary" className="full-page-content">
                            You should logged in...
                        </Alert>
                    </Row>
                </Container>
            );
        } else {
            return (
                <Container>
                    <Row>
                        <Alert color="primary" className="full-page-content">
                            Your components loading...
                        </Alert>
                    </Row>
                </Container>
            );
        }
    }
    //#endregion
};

//////////
//Values from redux
/////////
//#region
const mapStateToProps = state => {
    const { loading, wordsList, operationSuccess, operationFail, loginCheckStatus } = state.wordActions;

    return { loading, wordsList, operationSuccess, operationFail, loginCheckStatus };
};
//#endregion

export default connect(
    mapStateToProps,
    dispatch => bindActionCreators(wordActions, dispatch)
)(WordsPage);
