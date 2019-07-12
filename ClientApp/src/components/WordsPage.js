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
    ModalFooter
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
            modal: false
        };
    }

    componentWillMount() {
        this.props.getAllWords();
    }

    btnWordUpdate = (item) => {
        this.props.updateWord(item);
    }

    btnWordDelete = (item) => {
        this.props.deleteWord(item);
    }

    toggle = (item) => {
        this.setState(prevState => ({
            modal: !prevState.modal
        }));
    }

    WordTables = () => {
        if (this.props.wordsList.length > 0) {
            return this.props.wordsList.map((item, i) => {
                return (
                    <tr key={i}>
                        <td>{item.id}</td>
                        <td>{item.keyword}</td>
                        <td>{item.mean}</td>
                        <td>{item.status}</td>
                        <td>
                            <ButtonGroup>
                                <Button
                                    onClick={this.toggle.bind(this, item)}
                                >
                                    Güncelle
                                </Button>
                                <Button
                                    onClick={this.btnWordDelete.bind(this, item)}
                                >
                                    Sil
                                </Button>
                            </ButtonGroup>
                        </td>
                    </tr>
                );
            });
        }
    }

    WordOperationModal = () => {
        return (
            <Modal isOpen={this.state.modal} toggle={this.toggle}>
                <ModalHeader toggle={this.toggle}>Modal title</ModalHeader>
                <ModalBody>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </ModalBody>
                <ModalFooter>
                    <Button color="primary" onClick={this.toggle}>Do Something</Button>{' '}
                    <Button color="secondary" onClick={this.toggle}>Cancel</Button>
                </ModalFooter>
            </Modal>
        );
    }

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
                        <Table className='table table-bordered'>
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Keyword</th>
                                    <th>Mean</th>
                                    <th>Status</th>
                                    <th>Operations</th>
                                </tr>
                            </thead>
                            <tbody>
                                {this.WordTables()}
                            </tbody>
                        </Table>
                    </Row>
                    {this.WordOperationModal()}
                </Container>
            );
        } else {
            return (
                <Container>
                    <Row>
                        <Alert color="primary">
                            Your components loading...
                        </Alert>
                    </Row>
                </Container>
            );
        }
    }
};

const mapStateToProps = state => {
    const { loading, wordsList } = state.wordActions

    return { loading, wordsList };
};

export default connect(
    mapStateToProps,
    dispatch => bindActionCreators(wordActions, dispatch)
)(WordsPage);
