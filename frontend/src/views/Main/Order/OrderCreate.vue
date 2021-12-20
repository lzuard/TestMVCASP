<template>
  <showcase-create
    ref="form"
    v-bind="createData"
    @onSend="createOrder"
  />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import { required } from '@/utils/validation/i18n-validators'
import { useToast } from 'vue-toastification'

export default {
  name: 'OrderCreate',
  components: {
    ShowcaseCreate
  },
  setup () {
    const toast = useToast()
    return { toast }
  },
  data: () => {
    return {
      createData: {
        title: 'Создать заказ',
        fields: [
          {
            label: 'Клиент',
            type: 'select',
            modelValue: 'clientId',
            validation: { required },
            values: []
          },
          {
            label: 'Сотрудник',
            type: 'select',
            modelValue: 'employeeId',
            validation: { required },
            values: []
          },
          {
            label: 'ТК',
            type: 'select',
            modelValue: 'transportCompanyId',
            validation: { required },
            values: []
          },
          {
            label: 'Адрес',
            modelValue: 'addressId',
            placeholder: 'Адрес',
            validation: { required },
            type: 'select',
            values: []
          },
          {
            label: 'Номер ТТН',
            modelValue: 'ttnId',
            validation: { required },
            placeholder: 'ТТН',
            type: 'select',
            values: []
          },
          {
            label: 'Номер платежного документа',
            modelValue: 'paymentDocument',
            validation: { required },
            placeholder: 'Номер'
          },
          {
            label: 'Дата заказа',
            modelValue: 'orderingDate',
            validation: { required },
            type: 'date'
          },
          {
            label: 'Дата отгрузки',
            modelValue: 'shipmentDate',
            validation: { required },
            type: 'date'
          },
          {
            label: 'Дата доставки',
            modelValue: 'deliveryDate',
            validation: { required },
            type: 'date'
          },
          {
            label: 'Статус',
            modelValue: 'status',
            type: 'select',
            validation: { required },
            values: [
              {
                text: 'Принят',
                value: 0
              },
              {
                text: 'Завершен',
                value: 1
              },
              {
                text: 'Возврат',
                value: 2
              }
            ]
          },
          {
            label: 'Принято ТК',
            modelValue: 'isAcceptTransportCompany',
            type: 'checkbox',
            cols: ['col-auto']
          },
          {
            label: 'Принято клиентом',
            modelValue: 'isAcceptClient',
            type: 'checkbox',
            cols: ['col-auto']
          },
          {
            label: 'Примечание',
            placeholder: 'Примечание',
            modelValue: 'extra',
            type: 'textarea',
            cols: ['col-md-12']
          }
        ],
        enableAddedFields: true,
        subtitle: 'Товары в заказе',
        addedFields: [
          {
            label: 'Товар',
            placeholder: 'Артикул',
            type: 'select',
            modelValue: 'productId',
            values: []
          },
          {
            label: 'Количество',
            placeholder: 'Кол-во',
            type: 'number',
            modelValue: 'quantity'
          }
        ]
      }
    }
  },
  created () {
    this.$api.agent.getAgentByCategory(1)
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'clientId').values = data.map(item => {
          return Object.assign({}, {
            text: item.organizationName,
            value: item.id
          })
        })
      })

    this.$api.agent.getAgentByCategory(3)
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'transportCompanyId').values = data.map(item => {
          return Object.assign({}, {
            text: item.organizationName,
            value: item.id
          })
        })
      })

    this.$api.employee.getEmployee()
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'employeeId').values = data.map(item => {
          return Object.assign({}, {
            text: `${item.secondName} ${item.firstName} ${item.thirdName}`,
            value: item.id
          })
        })
      })

    this.$api.address.getAddressForUsing()
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'addressId').values = data.map(item => {
          return Object.assign({}, {
            text: `${item.index}, ${item.subject}, ${item.location}, ${item.street}, ${item.house}`,
            value: item.id
          })
        })
      })

    this.$api.ttn.getTTNForUsing()
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'ttnId').values = data.map(item => {
          return Object.assign({}, {
            text: item.number,
            value: item.id
          })
        })
      })

    this.$api.product.getProductsForUsing()
      .then((data) => {
        this.createData.addedFields.find(item => item.modelValue === 'productId').values = data.map(innerItem => {
          return {
            text: `${innerItem.name} | Артикул: ${innerItem.art}`,
            value: innerItem.id
          }
        })
      })
  },
  methods: {
    createOrder (data, additional) {
      const newData = { ...data, orderProducts: additional }

      this.$api.order.createOrder(newData)
        .then(() => {
          this.toast.success('Заказ успешно создан')
          this.$refs.form.clearForm()
        })
        .catch(() => {
          this.toast.error('Ошибка при создании заказа, повторите позже')
        })
    }
  }
}
</script>
