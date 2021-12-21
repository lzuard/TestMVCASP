<template>
  <showcase-create ref="form" @onSend="createSupply" v-bind="createData" />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import { required } from '@/utils/validation/i18n-validators'
import { useToast } from 'vue-toastification'

export default {
  name: 'SupplyCreate',
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
        title: 'Создать поставку',
        fields: [
          {
            label: 'Поставщик',
            placeholder: 'Выберите поставщика',
            modelValue: 'supplierId',
            type: 'select',
            validation: { required },
            values: []
          },
          {
            label: 'Сотрудник',
            placeholder: 'Выберите сотрудника',
            modelValue: 'employeeId',
            type: 'select',
            validation: { required },
            values: []
          },
          {
            label: 'ТК',
            placeholder: 'ТК',
            modelValue: 'transportCompanyId',
            type: 'select',
            validation: { required },
            values: []
          },
          {
            label: 'Номер ТТН',
            placeholder: 'ТТН',
            modelValue: 'ttnId',
            type: 'select',
            validation: { required },
            values: []
          },
          {
            label: 'Номер платежного документа',
            placeholder: 'Номер платежного док',
            modelValue: 'paymentDocument',
            validation: { required }
          },
          {
            label: 'Дата поставки',
            modelValue: 'supplyDate',
            type: 'date',
            validation: { required }
          },
          {
            label: 'Примечание',
            placeholder: 'Примечание',
            modelValue: 'extra',
            type: 'textarea',
            cols: ['col-md-12']
          },
          {
            label: 'Принято',
            modelValue: 'isAccepted',
            cols: ['col-auto'],
            type: 'checkbox'
          }
        ],
        enableAddedFields: true,
        subtitle: 'Товары на поставку',
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
    this.$api.agent.getAgentByCategory(2)
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'supplierId').values = data.map(item => {
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
    createSupply (data, additional) {
      const newData = { ...data, supplyProducts: additional }

      this.$api.supply.createSupply(newData)
        .then(() => {
          this.toast.success('Поставка успешно создана')
          this.$refs.form.clearForm()
        })
        .catch(() => {
          this.toast.error('Ошибка при создании поставки, повторите позже')
        })
    }
  }
}
</script>
